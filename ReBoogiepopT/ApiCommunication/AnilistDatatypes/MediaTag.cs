using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines field in Json response of type MediaTag.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaTag
    {
        private readonly int id;
        private readonly string name;
        private readonly string description;
        private readonly string category;

        public int Id => id;
        public string Name => name;
        public string Description => description;
        public string Category => category;
    }
}
