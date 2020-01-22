using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class describes a field of type MediaListCollection in a Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaListCollection
    {
        private readonly bool hasNextChunk;
        private readonly User user;
        private readonly List<MediaListGroup> lists;

        public bool HasNextChunk => hasNextChunk;
        public User User => user;
        public List<MediaListGroup> Lists => lists;
    }
}
