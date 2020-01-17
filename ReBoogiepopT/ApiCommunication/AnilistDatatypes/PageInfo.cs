using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines pageInfo field from a Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class PageInfo
    {
        private readonly int currentPage;
        private readonly int lastPage;

        public int CurrentPage => currentPage;
        public int LastPage => lastPage;
    }
}
