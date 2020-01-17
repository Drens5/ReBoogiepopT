using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines favourites field in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Favourites
    {
        private readonly MediaConnection anime;

        public MediaConnection Anime => anime;
    }
}
