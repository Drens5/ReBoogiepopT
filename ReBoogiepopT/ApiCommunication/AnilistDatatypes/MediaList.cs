using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines a field in Json response of type MediaList.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaList
    {
        private readonly MediaListStatus status;
        private readonly Media media;

        public MediaListStatus Status => status;
        public Media Media => media;
    }
}
