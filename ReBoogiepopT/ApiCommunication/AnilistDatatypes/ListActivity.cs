using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines activity field of type ListActivity in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class ListActivity
    {
        private readonly User user;
        private readonly String status;
        // The list item's textual status, can be: "completed", "watched episode", "paused watching", "plans to watch", ?"dropped"

        public User User => user;
        public string Status => status;
    }
}
