using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Namespace defines the classes which are used to serialize variables for operation requests.
/// </summary>
namespace ReBoogiepopT.ApiCommunication.OperationObjects.Variables
{
    /// <summary>
    /// Class defines a possible variable field for a GraphQL operation request in which the page and mediaId variable is provided.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class PageAndMediaId
    {
        private readonly int page;
        private readonly int mediaId;

        public PageAndMediaId(int page, int mediaId)
        {
            this.page = page;
            this.mediaId = mediaId;
        }
    }
}
