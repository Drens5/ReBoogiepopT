using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    static public class Aggregation
    {
        /// <summary>
        /// Turns the list of mediaList into a nubbed list with the count of the same media occurence recorded.
        /// </summary>
        /// <param name="entries">List of entries consisting of media and status.</param>
        /// <returns>List of media with the count from the input list recorded.</returns>
        static public List<CountMedia> NubC(List<MediaList> entries)
        {
            List<CountMedia> nubC = new List<CountMedia>(500);
            // My whole anime list fits in here with space to spare, fine for initial and will likely grow.

            foreach (MediaList entry in entries)
            {
                CountMedia countMedia = nubC.Find(m => m.Media.Id == entry.Media.Id);

                // Media not in nubC, therefore add it with a count of one.
                if (countMedia == null)
                    nubC.Add(new CountMedia(entry.Media));
                // Otherwise add to the counter of occurences.
                else
                    countMedia.Count++;
            }
            return nubC;
        }

        /// <summary>
        /// Comparison delegate to sort descending on local popularity.
        /// </summary>
        /// <remarks>That is the popularity based on selected users.</remarks>
        static public Comparison<CountMedia> LocalPopularity = (x, y) => y.Count - x.Count;

        /// <summary>
        /// Comparison delegate to sort descending on global popularity.
        /// </summary>
        static public Comparison<CountMedia> GlobalPopularity = (x, y) => y.Media.Popularity - x.Media.Popularity;

        /// <summary>
        /// Comparison delegate to sort descending on global mean score.
        /// </summary>
        static public Comparison<CountMedia> MeanScore = (x, y) => y.Media.MeanScore - x.Media.MeanScore;



        /// <summary>
        /// Filters out media that the user has already seen.
        /// </summary>
        /// <param name="countMediaList">List of media to filter.</param>
        /// <param name="userList">List of media to filter by.</param>
        /// <returns>List of CountMedia with media from userList removed.</returns>
        static public List<CountMedia> NubUR(List<CountMedia> countMediaList, List<MediaList> userList)
        {
            // Predicate whether a CountMedia (cm) is not on the user's list.
            Func<CountMedia, bool> userHasNotSeen = cm => !userList.Exists(ulm => cm.Media.Id == ulm.Media.Id);
            return countMediaList.Where<CountMedia>(userHasNotSeen).ToList();
        }

        /// <summary>
        /// Filters down to media that satisfies the coupled tags.
        /// </summary>
        /// <param name="countMedias">List of media to be filtered.</param>
        /// <param name="coupledTags">Coupled tags to filter by.</param>
        /// <returns>List of CountMedia only with media satisfying the coupled tags.</returns>
        static public List<CountMedia> NubT(List<CountMedia> countMedias, List<CoupledTag> coupledTags)
        {
            return countMedias.Where<CountMedia>(cm =>
            {
                foreach (CoupledTag coupledTag in coupledTags)
                {
                    if (!coupledTag.Satisfies(cm.Media))
                        return false;
                }
                return true;
            }).ToList();
        }

        /// <summary>
        /// Filters a list of selected media from its inject media.
        /// </summary>
        /// <param name="countMedias"></param>
        /// <returns>List of selected with inject media removed.</returns>
        static public List<CountMedia> NubF(List<CountMedia> countMedias)
        {
            throw new NotImplementedException("You know the dill.");
        }
    }
}
