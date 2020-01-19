using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines field in Json response of type Userstatistics.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class UserStatistics
    {
        private readonly int count;
        private readonly int minutesWatched;
        private readonly List<UserGenreStatistic> genres;
        private readonly List<UserTagStatistic> tags;

        public int Count => count;
        public int MinutesWatched => minutesWatched;
        public List<UserGenreStatistic> Genres => genres;
        public List<UserTagStatistic> Tags => tags;
    }
}
