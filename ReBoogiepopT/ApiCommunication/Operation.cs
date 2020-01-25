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
        static async private Task<HttpResponseMessage> SafeRequest(StringContent requestBody, StringContent requestBodyForRetry)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, requestBody);

                // Account of Rate-Limiting.
                // Doing a request takes about 730ms, so this is never true. Use more sophisticated parallelism to speed this up.
                if (response.Headers?.RetryAfter?.Delta != null)
                {

                    // Wait for the specified amount of time.
                    int waitTimeInMilliseconds = (int)Math.Ceiling(response.Headers.RetryAfter.Delta.Value.TotalMilliseconds);
                    Thread.Sleep(waitTimeInMilliseconds);

                    // Retry request after waiting.
                    response = await client.PostAsync(client.BaseAddress, requestBodyForRetry);
                }
                response.EnsureSuccessStatusCode();

                return response;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }


        /// <summary>
        /// Makes a request and deserializes the response to a TopLevel object.
        /// </summary>
        /// <param name="requestBody">Request body to send as Json.</param>
        /// <returns>Response as a TopLevel object.</returns>
        static async private Task<TopLevel> SafeRequestAndDeserializeResponse(StringContent requestBody, StringContent requestBodyForRetry)
        {
            HttpResponseMessage response = await SafeRequest(requestBody, requestBodyForRetry);
            string responseBody = await response.Content.ReadAsStringAsync();
            TopLevel responseObject = JsonConvert.DeserializeObject<TopLevel>(responseBody, new Newtonsoft.Json.Converters.StringEnumConverter());
            return responseObject;
        }


        /// <summary>
        /// Performs an operation that fetches the last page number on the activity pages of the media specified by mediaId.
        /// </summary>
        /// <param name="mediaId">Id of the media for which the last number of the amount of pages is queried for.</param>
        /// <returns>Last page number.</returns>
        static async public Task<int> PageListActivityInfoLastPage(int mediaId)
        {
            PageAndMediaId variables = new PageAndMediaId(1, mediaId);
            Service service = new Service(pageListActivityInfoLastPageQuery, variables);
            string serializedService = JsonConvert.SerializeObject(service);
            StringContent requestBody = new StringContent(serializedService, Encoding.UTF8, "application/json");
            StringContent requestBodyForRetry = new StringContent(serializedService, Encoding.UTF8, "application/json");

            TopLevel responseObject = await SafeRequestAndDeserializeResponse(requestBody, requestBodyForRetry);

            return responseObject.Data.Page.PageInfo.LastPage;
        }


        /// <summary>
        /// Fetches a page of activity of the media.
        /// </summary>
        /// <param name="page">Number of the page to fetch.</param>
        /// <param name="mediaId">Id of the media that the activity page is being querried for.</param>
        /// <returns>The Page.</returns>
        static async public Task<Page> PageListActivityInfo(int page, int mediaId)
        {
            PageAndMediaId variables = new PageAndMediaId(page, mediaId);
            Service service = new Service(pageListActivityInfo, variables);
            string serializedService = JsonConvert.SerializeObject(service);
            StringContent requestBody = new StringContent(serializedService, Encoding.UTF8, "application/json");
            StringContent requestBodyForRetry = new StringContent(serializedService, Encoding.UTF8, "application/json");

            TopLevel responseObject = await SafeRequestAndDeserializeResponse(requestBody, requestBodyForRetry);

            return responseObject.Data.Page;
        }


        /// <summary>
        /// Fetches a user's favourites and statistics
        /// </summary>
        /// <param name="name">Name to find the user by.</param>
        /// <returns>User information or null on HttpRequestException.</returns>
        static async public Task<User> UserFavoritesStatistics(string name)
        {
            Name variables = new Name(name);
            Service service = new Service(userFavoritesStatistics, variables);
            string serializedService = JsonConvert.SerializeObject(service);
            StringContent requestBody = new StringContent(serializedService, Encoding.UTF8, "application/json");
            StringContent requestBodyForRetry = new StringContent(serializedService, Encoding.UTF8, "application/json");
            try
            {
                TopLevel responseObject = await SafeRequestAndDeserializeResponse(requestBody, requestBodyForRetry);
                return responseObject.Data.User;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }


        /// <summary>
        /// Fetches the list of all the non plan to watch media on a user's list tagged with their status.
        /// </summary>
        /// <remarks>Edit the query to fetch plan to watch media as well.</remarks>
        /// <param name="userId">Id of user to get list of.</param>
        /// <returns>List of all non-plan to watch media of user in a single list tagged with the status.</returns>
        static async public Task<List<MediaList>> UserMediaListDownToMediaList(int userId)
        {
            // Initialization
            bool hasNextChunk = true;
            int chunk = 0;

            // Accumulation, chunk size is 500.
            List<MediaList> mediaList = new List<MediaList>(500);

            while (hasNextChunk)
            {
                UserIdAndChunk variables = new UserIdAndChunk(userId, ++chunk);
                Service service = new Service(userMediaList, variables);
                string serializedService = JsonConvert.SerializeObject(service);
                StringContent requestBody = new StringContent(serializedService, Encoding.UTF8, "application/json");
                StringContent requestBodyForRetry = new StringContent(serializedService, Encoding.UTF8, "application/json");

                TopLevel responseObject = await SafeRequestAndDeserializeResponse(requestBody, requestBodyForRetry);

                foreach (MediaListGroup list in responseObject.Data.MediaListCollection.Lists)
                {
                    mediaList.AddRange(list.Entries);
                }

                // Update
                hasNextChunk = responseObject.Data.MediaListCollection.HasNextChunk;
            }

            return mediaList;
        }
    }
}
