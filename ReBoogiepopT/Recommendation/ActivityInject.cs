using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    /// <summary>
    /// Class encapsulates functionality of the ActivityInject recommendation method which assigns users for aggregation based on
    /// activity on a certain media (or collection of media).
    /// </summary>
    public class ActivityInject
    {
        /// <summary>
        /// Media to query for user activity.
        /// </summary>
        private readonly List<int> injectMedia;

        /// <summary>
        /// For each injectMedia how many users to select.
        /// </summary>
        private readonly int injectAmount;

        /// <summary>
        /// List activity status selection.
        /// </summary>
        private readonly ListActivityStatusSelection listActivityStatusSelection;

        /// <summary>
        /// The user to which the recommendation may be tailored.
        /// </summary>
        /// <remarks>May reasonably be null, account for in usage!</remarks>
        private readonly User pAuth;

        /// <summary>
        /// A list of coupled tags to filter the media with.
        /// </summary>
        /// <remarks>May reasonably be null.</remarks>
        private readonly List<CoupledTag> cTags;

        public ActivityInject(List<int> injectMedia, int injectAmount, ListActivityStatusSelection listActivityStatusSelection)
        {
            this.injectMedia = injectMedia;
            this.injectAmount = injectAmount;
            this.listActivityStatusSelection = listActivityStatusSelection;
        }

        public ActivityInject(List<int> injectMedia, int injectAmount, ListActivityStatusSelection listActivityStatusSelection, User user)
            : this(injectMedia, injectAmount, listActivityStatusSelection)
        {
            pAuth = user;
        }

        public ActivityInject(List<int> injectMedia, int injectAmount, ListActivityStatusSelection listActivityStatusSelection, List<CoupledTag> cTags)
            : this(injectMedia, injectAmount, listActivityStatusSelection)
        {
            this.cTags = cTags;
        }

        public ActivityInject(List<int> injectMedia, int injectAmount, ListActivityStatusSelection listActivityStatusSelection, User user,
            List<CoupledTag> cTags) : this(injectMedia, injectAmount, listActivityStatusSelection, user)
        {
            this.cTags = cTags;
        }

        /// <summary>
        /// Enum that encodes the options of user selection based on list activity status of a certain media.
        /// </summary>
        public enum ListActivityStatusSelection { All, CompletedOnly, NotPlanning }

        /// <summary>
        /// Uses activity inject's method of selecting anime based on inject media.
        /// </summary>
        /// <returns>Nubbed list of selected media.</returns>
        public async Task<List<Media>> ActivityInjectMediaSelection()
        {
            List<CountMedia> mediaInQuestion = await RunActivityInject();
            return mediaInQuestion.Select(cm => cm.Media).ToList();
        }

        /// <summary>
        /// Run the activity inject recommendation method with the settings in this instance.
        /// </summary>
        /// <returns>All the media that appeared with the amount of occurences.</returns>
        public async Task<List<CountMedia>> RunActivityInject()
        {
            List<int> selectedUsers = new List<int>(injectMedia.Count * injectAmount);
            List<MediaList> entriesToAggregate = new List<MediaList>(selectedUsers.Count * 400);
            // Maximum chunk size is 500.

            // Select users based on the conditions defined in this instance.
            foreach (int mediaId in injectMedia)
                selectedUsers.AddRange(await selectUsers(mediaId));

            // Fetch list of selected users.
            foreach (int userId in selectedUsers)
                entriesToAggregate.AddRange(await Operation.UserMediaListDownToMediaList(userId));

            // If added: filtering based on media status on list would come here.
            // ---

            // Minimal aggregation
            List<CountMedia> mediaInQuestion = Aggregation.NubC(entriesToAggregate);

            if (pAuth != null)
            {
                List<MediaList> pAuthEntries = await Operation.UserMediaListDownToMediaList(pAuth.Id);

                // Remove media known to the pAuthUser
                mediaInQuestion = Aggregation.NubUR(mediaInQuestion, pAuthEntries);
            }
            
            if (cTags != null)
                // Filter to media that satisfies the coupled tags.
                mediaInQuestion = Aggregation.NubT(mediaInQuestion, cTags);

            return mediaInQuestion;
        }

        /// <summary>
        /// Selects users using the activity feed of the specified media.
        /// </summary>
        /// <remarks>Users selected are dependent on the fields set in this instance e.g. listActivityStatusSelection or injectAmount. </remarks>
        /// <remarks>At least as many users as injectAmmount specifies are selected. Unless there aren't enough users satisfying the specified
        /// conditions, then the amount gathered so far is returned.</remarks>
        /// <param name="mediaId">Media to select from.</param>
        /// <returns>List of selected users.</returns>
        public async Task<List<int>> selectUsers(int mediaId)
        {
            int lastPage = await Operation.PageListActivityInfoLastPage(mediaId);
            List<int> selectedUsers = new List<int>(injectAmount);

            while (selectedUsers.Count < injectAmount && lastPage > 0)
            {
                Page page = await Operation.PageListActivityInfo(lastPage--, mediaId);
                foreach (ListActivity activity in page.Activities)
                {
                    // Conditions to select users with come here.
                    if (checkListActivityStatus(activity))
                        selectedUsers.Add(activity.User.Id);
                    else continue;
                }
            }
            return selectedUsers;
        }

        /// <summary>
        /// A predicate to filter activity which satisfies the ListActivityStatus required.
        /// </summary>
        /// <param name="activity">Activity to be checked.</param>
        /// <returns>True if the status of the activity is in line with the set listActivityStatus.</returns>
        private bool checkListActivityStatus(ListActivity activity)
        {
            switch (listActivityStatusSelection)
            {
                case ListActivityStatusSelection.All:
                    return true;
                case ListActivityStatusSelection.CompletedOnly:
                    if (activity.Status == "completed")
                        return true;
                    else return false;
                case ListActivityStatusSelection.NotPlanning:
                    if (activity.Status != "plans to watch")
                        return true;
                    else return false;
                default:
                    throw new ArgumentException("Invalid ListActivityStatusSelection: " + listActivityStatusSelection.ToString());
            }
        }

    }
}
