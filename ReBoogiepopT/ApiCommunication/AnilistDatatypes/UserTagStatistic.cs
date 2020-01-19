using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines a field in Json response of type UserTagStatistic.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class UserTagStatistic
    {
        private readonly int count;
        private readonly int minutesWatched;
        private readonly MediaTag tag;

        public int Count => count;
        public int MinutesWatched => minutesWatched;
        public MediaTag Tag => tag;
    }
}
