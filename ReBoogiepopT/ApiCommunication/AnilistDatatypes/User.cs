using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines the User field in a Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class User
    {
        private readonly int id;
        private readonly string name;
        private readonly Favourites favourites;
        private readonly UserStatisticTypes statistics;
        private readonly string siteUrl;

        public int Id => id;
        public string Name => name;
        public Favourites Favourites => favourites;
        public UserStatisticTypes Statistics => statistics;
        public string SiteUrl => siteUrl;
    }
}
