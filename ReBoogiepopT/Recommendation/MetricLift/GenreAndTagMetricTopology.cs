using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation.MetricLift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation.MetricLift
{
    /// <summary>
    /// Class defines metric topologies of tags and genres and between them.
    /// The topology defined is based on the user.
    /// </summary>
    public class GenreAndTagMetricTopology
    {
        private List<TagStatInfo> tagsStatInfo;
        private List<GenreStatInfo> genresStatInfo;

        private readonly string pAuthUserName;

        /// <summary>
        /// Flag for members to check on invocation.
        /// Throw exception if a member tries to do something without the class being initialized.
        /// </summary>
        private bool initialized = false;

        public GenreAndTagMetricTopology(string userName)
        {
            pAuthUserName = userName;
        }

        /// <summary>
        /// Does all asynchronous operations, querying the anilist api, and sets up the relevant data to define the metric.
        /// Must be run before any other operation.
        /// </summary>
        /// <returns>Task, async void</returns>
        public async Task Initialize()
        {
            List<string> genreCollection = await Operation.GenreCollection();
            List<MediaTag> tagCollection = await Operation.TagCollection();

            User pAuth = await Operation.UserFavoritesStatistics(pAuthUserName);

            genresStatInfo = genreCollection.Select(name =>
            {
                UserGenreStatistic cgs = pAuth.Statistics.Anime.Genres.Find(gs => gs.Genre == name);
                return cgs == null ? new GenreStatInfo(name) : new GenreStatInfo(name, cgs.Count, cgs.MinutesWatched);
            }).ToList();

            tagsStatInfo = tagCollection.Select(tag =>
            {
                UserTagStatistic cts = pAuth.Statistics.Anime.Tags.Find(ts => ts.Tag.Name == tag.Name);
                return cts == null ? new TagStatInfo(tag.Name, tag.Category)
                    : new TagStatInfo(tag.Name, tag.Category, cts.Count, cts.MinutesWatched);
            }).ToList();

            initialized = true;
        }
    }
}
