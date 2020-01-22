using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines a field of type MediaCoverImage in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaCoverImage
    {
        private readonly string large;
        private readonly string medium;

        public string Large => large;
        public string Medium => medium;
    }
}
