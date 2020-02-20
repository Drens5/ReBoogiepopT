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

        private const int constNonRelevancy = 2;
        private const int constRelevancy = 1;

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

        /// <summary>
        /// Metric function based on count for genres.
        /// </summary>
        /// <param name="g1">Genre 1</param>
        /// <param name="g2">Genre 2</param>
        /// <remarks>This turns the set of genres into a metric space.</remarks>
        /// <returns>The distance between the two genres.</returns>
        public int CountMetric(GenreStatInfo g1, GenreStatInfo g2)
        {
            if (!initialized)
                throw new Exception("Instance not explicitly initialized.");

            if (g1 == null)
                throw new ArgumentNullException(nameof(g1));
            if (g2 == null)
                throw new ArgumentNullException(nameof(g2));

            if (g1.Name == g2.Name)
                return 0;
            return Math.Abs(g1.Count - g2.Count) + constNonRelevancy;
        }

        /// <summary>
        /// Metric function based on count for tags.
        /// </summary>
        /// <param name="t1">Tag 1</param>
        /// <param name="t2">Tag 2</param>
        /// <remarks>This turns the set of tags into a metric space.</remarks>
        /// <returns>The distance between two tags.</returns>
        public int CountMetric(TagStatInfo t1, TagStatInfo t2)
        {
            if (!initialized)
                throw new Exception("Instance not explicitly initialized.");

            if (t1 == null)
                throw new ArgumentNullException(nameof(t1));
            if (t2 == null)
                throw new ArgumentNullException(nameof(t2));

            if (t1.Name == t2.Name)
                return 0;
            if (t1.Category == t2.Category)
                return Math.Abs(t1.Count - t2.Count) + constRelevancy;
            return Math.Abs(t1.Count - t2.Count) + constNonRelevancy;
        }

        /// <summary>
        /// Metric function based on count between genre and tag.
        /// </summary>
        /// <param name="g">Genre</param>
        /// <param name="t">Tag</param>
        /// <remarks>By defining symmetry in the arguments this turns the set of genres and tags in a metric space.</remarks>
        /// <returns>The distance between the genre and the tag.</returns>
        public int CountMetric(GenreStatInfo g, TagStatInfo t)
        {
            if (!initialized)
                throw new Exception("Instance not explicitly initialized.");

            if (g == null)
                throw new ArgumentNullException(nameof(g));
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            return Math.Abs(g.Count - t.Count) + constNonRelevancy;
        }

        /// <summary>
        /// Symmetry for CountMetric(g, t).
        /// </summary>
        /// <param name="t">Tag</param>
        /// <param name="g">Genre</param>
        /// <returns>Distance between g and t.</returns>
        public int CountMetric(TagStatInfo t, GenreStatInfo g)
        {
            return CountMetric(g, t);
        }

        /// <summary>
        /// Symmetry for MinutesWatchedMetric(g, t).
        /// </summary>
        /// <param name="t">Tag</param>
        /// <param name="g">Genre</param>
        /// <returns>Distance between g and t (in terms of minutes watched).</returns>
        public int MinutesWatchedMetric(TagStatInfo t, GenreStatInfo g)
        {
            return MinutesWatchedMetric(g, t);
        }

        /// <summary>
        /// Metric function based on minutes watched between genre and tag.
        /// </summary>
        /// <param name="g">Genre</param>
        /// <param name="t">Tag</param>
        /// <remarks>By defining symmetry in the arguments this turns the set of genres and tags in a metric space.</remarks>
        /// <returns>The distance between the genre and the tag.</returns>
        public int MinutesWatchedMetric(GenreStatInfo g, TagStatInfo t)
        {
            if (!initialized)
                throw new Exception("Instance not explicitly initialized.");

            if (g == null)
                throw new ArgumentNullException(nameof(g));
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            return Math.Abs(g.MinutesWatched - t.MinutesWatched) + constNonRelevancy;
        }

        /// <summary>
        /// Metric function based on minutes watched for tags.
        /// </summary>
        /// <param name="t1">Tag 1</param>
        /// <param name="t2">Tag 2</param>
        /// <returns>The distance between two tags (in terms of minutes watched).</returns>
        public int MinutesWatchedMetric(TagStatInfo t1, TagStatInfo t2)
        {
            if (!initialized)
                throw new Exception("Instance not explicitly initialized.");

            if (t1 == null)
                throw new ArgumentNullException(nameof(t1));
            if (t2 == null)
                throw new ArgumentNullException(nameof(t2));

            if (t1.Name == t2.Name)
                return 0;
            if (t1.Category == t2.Category)
                return Math.Abs(t1.MinutesWatched - t2.MinutesWatched) + constRelevancy;
            return Math.Abs(t1.MinutesWatched - t2.MinutesWatched) + constNonRelevancy;
        }

        /// <summary>
        /// Metric function based on minutes watched for genres.
        /// </summary>
        /// <param name="g1">Genre 1</param>
        /// <param name="g2">Genre 2</param>
        /// <returns>The distance between the two genres (in terms of minutes watched).</returns>
        public int MinutesWatchedMetric(GenreStatInfo g1, GenreStatInfo g2)
        {
            if (!initialized)
                throw new Exception("Instance not explicitly initialized.");

            if (g1 == null)
                throw new ArgumentNullException(nameof(g1));
            if (g2 == null)
                throw new ArgumentNullException(nameof(g2));

            if (g1.Name == g2.Name)
                return 0;
            return Math.Abs(g1.MinutesWatched - g2.MinutesWatched) + constNonRelevancy;
        }
    }
}
