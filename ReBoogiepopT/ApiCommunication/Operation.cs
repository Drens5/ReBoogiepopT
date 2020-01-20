using Newtonsoft.Json;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.ApiCommunication.OperationObjects;
using ReBoogiepopT.ApiCommunication.OperationObjects.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReBoogiepopT.ApiCommunication
{
    /// <summary>
    /// Class defines all functionality and relevancy of doing a GraphQL service operation with anilist's Api.
    /// </summary>
    static public partial class Operation
    {
        static private readonly HttpClient client;

        static Operation()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://graphql.anilist.co");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Makes a (Json) post request accounting for the Rate Limiting to the anilist Api.
        /// </summary>
        /// <param name="requestBody">Json body to be sent with the request.</param>
        /// <returns>The response of the request made.</returns>
        /// <remarks>May throw an HttpRequestException.</remarks>
        static async private Task<HttpResponseMessage> SafeRequest(StringContent requestBody)
        {
            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, requestBody);

            // Account of Rate-Limiting.
            // Doing a request takes about 800ms, so this is never true. Use more sophisticated parallelism to speed this up.
            if (response.Headers?.RetryAfter?.Delta != null)
            {

                // Wait for the specified amount of time.
                int waitTimeInMilliseconds = (int)Math.Ceiling(response.Headers.RetryAfter.Delta.Value.TotalMilliseconds);
                Thread.Sleep(waitTimeInMilliseconds);

                // Retry request after waiting.
                response = await client.PostAsync(client.BaseAddress, requestBody);
            }
            response.EnsureSuccessStatusCode();

            return response;
        }

        /// <summary>
        /// Performs an operation that fetches the last page number on the activity pages of the media specified by mediaId.
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns>last page number.</returns>
        static async public Task<int> PageListActivityInfoLastPage(int mediaId)
        {
            PageAndMediaId variables = new PageAndMediaId(1, mediaId);
            Service service = new Service(pageListActivityInfoLastPageQuery, variables);
            string serializedService = JsonConvert.SerializeObject(service);
            StringContent requestBody = new StringContent(serializedService, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await SafeRequest(requestBody);
                string responseBody = await response.Content.ReadAsStringAsync();
                TopLevel responseObject = JsonConvert.DeserializeObject<TopLevel>(responseBody);
                return responseObject.Data.Page.PageInfo.LastPage;
            }
            catch(HttpRequestException)
            {
                throw;
            }

        }

    }
}
