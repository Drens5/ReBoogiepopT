using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication.OperationObjects
{
    /// <summary>
    /// Class defines the object to be serialized in order to send a valid GraphQL operation request.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Service
    {
        private readonly string query;
        private readonly object variables;

        public Service(string query, object variables)
        {
            this.query = query;
            this.variables = variables;
        }
    }
}
