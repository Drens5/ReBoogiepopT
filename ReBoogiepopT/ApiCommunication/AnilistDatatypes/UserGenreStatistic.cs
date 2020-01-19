using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines field in Json response of type UserGenreStatistic.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class UserGenreStatistic
    {
        private readonly int count;
        private readonly int minutesWatched;
        private readonly string genre;

        public int Count => count;
        public int MinutesWatched => minutesWatched;
        public string Genre => genre;
    }
}
