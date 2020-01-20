using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication
{
    /// <summary>
    /// Defines queries for serialization.
    /// </summary>
    static public partial class Operation
    {
        // Query to get the last page on the activities of the media specified by mediaId.
        static private readonly string pageListActivityInfoLastPageQuery = @"
            query pageListActivityInfoLastPageQuery($page: Int!, $mediaId: Int!) {
              Page(perPage: 50, page: $page) {
                pageInfo {
                  lastPage
                }
    
                activities(mediaId: $mediaId, type: ANIME_LIST){
                  ... on ListActivity {
                    id
                  }
                }
              }
            }
        ";
    }
}
