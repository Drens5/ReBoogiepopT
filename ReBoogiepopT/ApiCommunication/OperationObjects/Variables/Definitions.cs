﻿using Newtonsoft.Json;
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
    /// Empty class to pass into a service to make a GraphQL operation request without variables.
    /// </summary>
    [JsonObject()]
    public class Empty
    {

    }

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


    /// <summary>
    /// Class defines a possible variable field for a GraphQL operation request in which the userId and chunk variables are provided.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class UserIdAndChunk
    {
        private readonly int userId;
        private readonly int chunk;

        public UserIdAndChunk(int userId, int chunk)
        {
            this.userId = userId;
            this.chunk = chunk;
        }
    }


    /// <summary>
    /// Class defines a possible variable field for a GraphQL operation request in which name of type string is provided.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Name
    {
        private readonly string name;

        public Name(string name)
        {
            this.name = name;
        }
    }

    /// <summary>
    /// Class defines a variable field for a GraphQL operation request in which a single id, called "id", is provided.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Id
    {
        private readonly int id;

        public Id(int id)
        {
            this.id = id;
        }
    }
}
