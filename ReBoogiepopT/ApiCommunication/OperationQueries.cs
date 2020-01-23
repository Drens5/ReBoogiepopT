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

        static private readonly string pageListActivityInfo = @"
            query pageListActivityInfo($page: Int!, $mediaId: Int!) {
              Page(perPage: 50, page: $page) {
                pageInfo {
                  currentPage
                  lastPage
                }
    
                activities(mediaId: $mediaId, type: ANIME_LIST){
                  ... on ListActivity {
                    user {
                      id
                      name
                    }
                    status
                  }
                }
              }
            }
        ";

        static private readonly string userMediaList = @"
            query userMediaList($userId: Int!, $chunk: Int!) {
              MediaListCollection(userId: $userId, type: ANIME,
                perChunk: 500, chunk: $chunk,
                  status_in: [CURRENT, COMPLETED, PAUSED, DROPPED, REPEATING]) {
                user {
                  id
                }
                hasNextChunk
                lists {
                  status
                  entries {
                    status
                    media {
                      id
                      title {
                        english
                        romaji
                        native
                      }
                      description
                      coverImage {
                        large
                        medium
                      }
                      meanScore
                      popularity
                      genres
                      tags {
                        id
                        name
                        rank
                      }
                    }
                  }
                }
              }
            }
        ";

        static private readonly string userFavoritesStatistics = @"
            query userFavoritesStatistics($name: String!) {
              User(name: $name) {
                id
                name
                siteUrl
                favourites {
                  anime {
                    nodes {
                      id
                      title {
                        english
                        native
                        romaji
                      }
                      meanScore
                      popularity
                      genres
                    }
                  }
                }
                statistics {
                  anime {
                    count
                    minutesWatched
                    genres {
                      count
                      minutesWatched
                      genre
                    }
                    tags {
                      count
                      minutesWatched
                      tag {
                        id
                        name
                        description
                        category
                      }
                    }
                  }
                }
              }
            }
        ";
    }
}
