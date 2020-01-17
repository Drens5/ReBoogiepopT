using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReBoogiepopT.ApiCommunication.AnilistDatatypes
{
    /// <summary>
    /// Class defines media field in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Media
    {
        private readonly int id;
        private readonly MediaTitle title;
        private readonly string description;
        private readonly MediaCoverImage coverImage;
        private readonly List<string> genres;
        private readonly int meanScore;
        private readonly int popularity;
        private readonly List<MediaTag> tags;

        public int Id => id;
        public MediaTitle Title => title;
        public string Description => description;
        public MediaCoverImage CoverImage => coverImage;
        public List<string> Genres => genres;
        public int MeanScore => meanScore;
        public int Popularity => popularity;
        public List<MediaTag> Tags => tags;
    }
}
