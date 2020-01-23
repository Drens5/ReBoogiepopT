using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    public enum MediaListStatus { CURRENT, PLANNING, COMPLETED, DROPPED, PAUSED, REPEATING }

    /// <summary>
    /// Class describes a field of type MediaListGroup in a Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaListGroup
    {
        private readonly MediaListStatus? status;
        private readonly List<MediaList> entries;

        public MediaListStatus? Status => status;
        public List<MediaList> Entries => entries;
    }
}
