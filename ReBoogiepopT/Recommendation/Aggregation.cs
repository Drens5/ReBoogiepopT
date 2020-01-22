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
            // My whole anime fits in here with space to spare, fine for initial and will likely grow.

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
    }
}
