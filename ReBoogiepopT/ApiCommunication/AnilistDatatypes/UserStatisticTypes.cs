using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines field of type UserStatisticTypes in the Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class UserStatisticTypes
    {
        private readonly UserStatistics anime;

        public UserStatistics Anime => anime;
    }
}
