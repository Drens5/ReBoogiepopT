using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines a field of type MediaConnection Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaConnection
    {
        private readonly List<Media> nodes;
        private readonly PageInfo pageInfo;

        public List<Media> Nodes => nodes;
        public PageInfo PageInfo => pageInfo;
    }
}
