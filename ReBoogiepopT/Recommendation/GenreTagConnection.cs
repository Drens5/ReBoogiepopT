using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation;
using ReBoogiepopT.Recommendation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopT.Recommendation
{
    /// <summary>
    /// Defines a connection between two genres or tags, or between a genre and a tag.
    /// </summary>
    class GenreTagConnection
    {
        /// <summary>
        /// Genre or tag 1.
        /// </summary>
        private readonly string got1;

        /// <summary>
        /// Genre or tag 2.
        /// </summary>
        private readonly string got2;

        /// <summary>
        /// Distance between got1 and got2.
        /// </summary>
        private readonly int distance;

        public GenreTagConnection(string got1, string got2, int distance)
        {
            this.got1 = got1;
            this.got2 = got2;
            this.distance = distance;
        }

        /// <summary>
        /// The set (of two elements) consisting of genres or tags 1 and 2 must be equal.
        /// </summary>
        /// <param name="got1">Genre or tag 1.</param>
        /// <param name="got2">Genre or tag 2.</param>
        /// <returns></returns>
        public bool SameConnection(string got1, string got2)
        {
            if (SameArrow(got1, got2) || SameArrow(got2, got1))
                return true;
            return false;
        }

        /// <summary>
        /// Genre or tag on 1 and 2 must be the same.
        /// </summary>
        /// <param name="got1">Genre or tag 1.</param>
        /// <param name="got2">Genre or tag 2.</param>
        /// <returns></returns>
        public bool SameArrow(string got1, string got2)
        {
            if (got1 == this.got1)
                if (got2 == this.got2)
                    return true;
            return false;
        }
    }
}
