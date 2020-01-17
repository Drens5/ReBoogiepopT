using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

/// <summary>
/// A datatype in this namespace need not have all possible Json response fields defined.
/// </summary>
namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines the entry point of a Json response.
    /// </summary>
    /// <remarks>Properties are ignored so we can use standard naming conventions.</remarks>
    [JsonObject(MemberSerialization.Fields)]
    public class TopLevel
    {
        readonly private Data data;
        // Explicit field used since "data" is the field in the Json.

        public Data Data => data;
    }

    /// <summary>
    /// Class that defines the object which contains the all possible fields of queried data.
    /// </summary>
    /// <remarks>When parsing a response only a (small) subset of the fields will likely be in use.</remarks>
    /// <remarks>All the fields on this level start with a capital letter, so no attribute necessary.</remarks>
    public class Data
    {
        public User User { get; }
    }
}
