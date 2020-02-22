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
    public class GenreAndTagStatInfo
    {
        public List<TagStatInfo> TagsStatInfo { get; set; }
        public List<GenreStatInfo> GenresStatInfo { get; set; }

        private readonly string pAuthUserName;

        /// <summary>
        /// Flag to check on invocation.
        /// Throw exception if a member tries to do something without the class being initialized.
        /// </summary>
        public bool Initialized { get; set; } = false;

        public GenreAndTagStatInfo(string userName)
        {
            pAuthUserName = userName;
        }

        /// <summary>
        /// Does all asynchronous operations, querying the anilist api, and sets up the relevant data.
        /// Must be run before any other operation.
        /// </summary>
        /// <returns>Task, async void</returns>
        public async Task Initialize()
        {
            List<string> genreCollection = await Operation.GenreCollection();
            List<MediaTag> tagCollection = await Operation.TagCollection();

            User pAuth = await Operation.UserFavoritesStatistics(pAuthUserName);

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
