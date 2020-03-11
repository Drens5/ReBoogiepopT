using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    /// <summary>
    /// Quicks gets data from userstatistics.
    /// </summary>
    public enum StatInfoMode { Quick, Sophisticated }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// There are multiple ways to do this: 1. statistics field from user query, 2. manually traversing list and aggregating tags and genres,
    /// 3. traversing only the favourites and aggregating the tags and genres.
    /// 1 and 2 are comparable in that 2 is finer than 1, since 1 is limited to 30 tags for non tier 3 donators. Method 2 bypasses that.
    /// </remarks>
    public class GenreAndTagStatInfo
    {
        public List<TagStatInfo> TagsStatInfo { get; set; }
        public List<GenreStatInfo> GenresStatInfo { get; set; }

        private readonly StatInfoMode mode;

        private readonly string pAuthUserName;

        private User pAuth;

        /// <summary>
        /// Flag to check on invocation.
        /// Throw exception if a member tries to do something without the class being initialized.
        /// </summary>
        public bool Initialized { get; set; } = false;

        public GenreAndTagStatInfo(string userName, StatInfoMode mode)
        {
            pAuthUserName = userName;
            this.mode = mode;
        }

        public GenreAndTagStatInfo(User user, StatInfoMode mode)
        {
            pAuth = user;
            this.mode = mode;
        }

        /// <summary>
        /// Does all asynchronous operations, querying the anilist api, and sets up the relevant data.
        /// Must be run before any other operation.
        /// </summary>
        /// <returns>Task, async void</returns>
        public async Task Initialize()
        {
            switch (mode)
            {
                case StatInfoMode.Quick:
                    await InitializeFromUserStatistics();
                    break;
                case StatInfoMode.Sophisticated:
                    await InitializeFromList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), "StatInfoMode mode passed is invalid!");
            }
        }

        public async Task InitializeFromList()
        {
            List<string> genreCollection = await Operation.GenreCollection();
            List<MediaTag> tagCollection = await Operation.TagCollection();

            if (pAuth == null)
                pAuth = await Operation.UserFavoritesStatistics(pAuthUserName);

            GenresStatInfo = genreCollection.Select(name =>
            {
                return new GenreStatInfo(name);
            }).ToList();

            TagsStatInfo = tagCollection.Select(tag =>
            {
                return new TagStatInfo(tag.Name, tag.Category);
            }).ToList();

            List<MediaList> userMediaListList = await Operation.UserMediaListDownToMediaList(pAuth.Id);

            foreach (MediaList medialist in userMediaListList)
            {
                foreach (string genre in medialist.Media.Genres)
                {
                    GenreStatInfo cgsi = GenresStatInfo.Find(gsi => gsi.Name == genre);
                    if (cgsi == null)
                        continue;
                    else
                    {
                        cgsi.Count += 1;
                        cgsi.MinutesWatched += medialist.Media.Duration * medialist.Progress;
                    }
                }

                foreach (MediaTag tag in medialist.Media.Tags)
                {
                    TagStatInfo ctsi = TagsStatInfo.Find(tsi => tsi.Name == tag.Name);
                    if (ctsi == null)
                        // Invalid tag.
                        continue;
                    else
                    {
                        ctsi.Count += 1;
                        ctsi.MinutesWatched += medialist.Media.Duration * medialist.Progress;
                    }
                }
            }

            Initialized = true;
        }

        public async Task InitializeFromUserStatistics()
        {
            List<string> genreCollection = await Operation.GenreCollection();
            List<MediaTag> tagCollection = await Operation.TagCollection();

            if (pAuth == null)
                pAuth = await Operation.UserFavoritesStatistics(pAuthUserName);

            GenresStatInfo = genreCollection.Select(name =>
            {
                UserGenreStatistic cgs = pAuth.Statistics.Anime.Genres.Find(gs => gs.Genre == name);
                return cgs == null ? new GenreStatInfo(name) : new GenreStatInfo(name, cgs.Count, cgs.MinutesWatched);
            }).ToList();

            TagsStatInfo = tagCollection.Select(tag =>
            {
                UserTagStatistic cts = pAuth.Statistics.Anime.Tags.Find(ts => ts.Tag.Name == tag.Name);
                return cts == null ? new TagStatInfo(tag.Name, tag.Category)
                    : new TagStatInfo(tag.Name, tag.Category, cts.Count, cts.MinutesWatched);
            }).ToList();

            Initialized = true;
        }
    }
}
