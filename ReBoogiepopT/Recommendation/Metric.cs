using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation;
using ReBoogiepopT.Recommendation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    public enum MetricMode {Count, MinutesWatched}

    /// <summary>
    /// Recommendation method which defines a metric on the set of all anime, turning this set into a metric space.
    /// Recommandation can e.g. be done by selecting anime in a neighborhood from a particular one and sorting by distance.
    /// </summary>
    public class Metric
    {
        private GenreAndTagStatInfo genreAndTagStatInfo;

        private const int constNonRelevancy = 2;
        private const int constRelevancy = 1;

        public Metric(GenreAndTagStatInfo genreAndTagStatInfo)
        {
            if (genreAndTagStatInfo == null)
                throw new ArgumentNullException(nameof(genreAndTagStatInfo));
            if (!genreAndTagStatInfo.Initialized)
                throw new Exception("Instance not explicitly initialized.");

            this.genreAndTagStatInfo = genreAndTagStatInfo;
        }

        /// <summary>
        /// Metric function based on minutes watched for genres or tags.
        /// Determines what each parameter is, either a genre or tag, and applies the correct metric function.
        /// </summary>
        /// <param name="got1">Genre or Tag 1</param>
        /// <param name="got2">Genre or Tag 2</param>
        /// <remarks>May throw an InvalidGenreOrTagException.</remarks>
        /// <returns>The distance between got1 and got2 (in terms of minutes watched).</returns>
        public int MinutesWatchedMetric(string got1, string got2)
        {
            GenreStatInfo gsi1 = genreAndTagStatInfo.GenresStatInfo.Find(gsi => gsi.Name == got1);
            if (gsi1 != null)
            {
                GenreStatInfo gsi2 = genreAndTagStatInfo.GenresStatInfo.Find(gsi => gsi.Name == got2);
                if (gsi2 != null)
                    return MinutesWatchedMetric(gsi1, gsi2);

                TagStatInfo tsi2 = genreAndTagStatInfo.TagsStatInfo.Find(tsi => tsi.Name == got2);
                if (tsi2 != null)
                    return MinutesWatchedMetric(gsi1, tsi2);

                throw new InvalidGenreOrTagException(got2 + " is not a valid genre or tag.");
            }

            TagStatInfo tsi1 = genreAndTagStatInfo.TagsStatInfo.Find(tsi => tsi.Name == got1);
            if (tsi1 != null)
            {
                GenreStatInfo gsi2 = genreAndTagStatInfo.GenresStatInfo.Find(gsi => gsi.Name == got2);
                if (gsi2 != null)
                    return MinutesWatchedMetric(tsi1, gsi2);

                TagStatInfo tsi2 = genreAndTagStatInfo.TagsStatInfo.Find(tsi => tsi.Name == got2);
                if (tsi2 != null)
                    return MinutesWatchedMetric(tsi1, tsi2);

                throw new InvalidGenreOrTagException(got2 + " is not a valid genre or tag.");
            }
            throw new InvalidGenreOrTagException(got1 + " is not a valid genre or tag.");
        }

        /// <summary>
        /// Metric function based on count for genres or tags.
        /// Determines what each parameter is, either a genre or tag, and applies the correct metric function.
        /// </summary>
        /// <param name="got1">Genre or Tag 1</param>
        /// <param name="got2">Genre or Tag 2</param>
        /// <remarks>May throw an InvalidGenreOrTagException.</remarks>
        /// <returns>The distance between got1 and got2.</returns>
        public int CountMetric(string got1, string got2)
        {
            GenreStatInfo gsi1 = genreAndTagStatInfo.GenresStatInfo.Find(gsi => gsi.Name == got1);
            if (gsi1 != null)
            {
                GenreStatInfo gsi2 = genreAndTagStatInfo.GenresStatInfo.Find(gsi => gsi.Name == got2);
                if (gsi2 != null)
                    return CountMetric(gsi1, gsi2);

                TagStatInfo tsi2 = genreAndTagStatInfo.TagsStatInfo.Find(tsi => tsi.Name == got2);
                if (tsi2 != null)
                    return CountMetric(gsi1, tsi2);

                throw new InvalidGenreOrTagException(got2 + " is not a valid genre or tag.");
            }

            TagStatInfo tsi1 = genreAndTagStatInfo.TagsStatInfo.Find(tsi => tsi.Name == got1);
            if (tsi1 != null)
            {
                GenreStatInfo gsi2 = genreAndTagStatInfo.GenresStatInfo.Find(gsi => gsi.Name == got2);
                if (gsi2 != null)
                    return CountMetric(tsi1, gsi2);

                TagStatInfo tsi2 = genreAndTagStatInfo.TagsStatInfo.Find(tsi => tsi.Name == got2);
                if (tsi2 != null)
                    return CountMetric(tsi1, tsi2);

                throw new InvalidGenreOrTagException(got2 + " is not a valid genre or tag.");
            }
            throw new InvalidGenreOrTagException(got1 + " is not a valid genre or tag.");
        }

        /// <summary>
        /// Metric function based on count for genres.
        /// </summary>
        /// <param name="g1">Genre 1</param>
        /// <param name="g2">Genre 2</param>
        /// <remarks>This turns the set of genres into a metric space.</remarks>
        /// <returns>The distance between the two genres.</returns>
        private int CountMetric(GenreStatInfo g1, GenreStatInfo g2)
        {
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
        private int CountMetric(TagStatInfo t1, TagStatInfo t2)
        {
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
        private int CountMetric(GenreStatInfo g, TagStatInfo t)
        {
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
        private int CountMetric(TagStatInfo t, GenreStatInfo g)
        {
            return CountMetric(g, t);
        }

        /// <summary>
        /// Symmetry for MinutesWatchedMetric(g, t).
        /// </summary>
        /// <param name="t">Tag</param>
        /// <param name="g">Genre</param>
        /// <returns>Distance between g and t (in terms of minutes watched).</returns>
        private int MinutesWatchedMetric(TagStatInfo t, GenreStatInfo g)
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
        private int MinutesWatchedMetric(GenreStatInfo g, TagStatInfo t)
        {
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
        private int MinutesWatchedMetric(TagStatInfo t1, TagStatInfo t2)
        {
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
        private int MinutesWatchedMetric(GenreStatInfo g1, GenreStatInfo g2)
        {
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
