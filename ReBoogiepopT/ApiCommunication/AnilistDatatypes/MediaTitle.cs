using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines a field of type mediaTitle in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaTitle
    {
        private readonly string romaji;
        private readonly string english;
        private readonly string native;

        public string Romaji => romaji;
        public string English => english;
        public string Native => native;
    }
}
