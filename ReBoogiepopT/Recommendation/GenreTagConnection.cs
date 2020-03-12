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
    public class GenreTagConnection
    {
        /// <summary>
        /// Genre or tag 1.
        /// </summary>
        public string GoT1 { get; }

        /// <summary>
        /// Genre or tag 2.
        /// </summary>
        public string GoT2 { get; }

        /// <summary>
        /// Distance between got1 and got2.
        /// </summary>
        private int distance;

        public int Distance { get => distance; }

        /// <summary>
        /// Halven the distance and round up.
        /// </summary>
        /// <remarks>
        /// One may consider if it's worth using doubles instead of integers. But only in the case of distance = 2 is
        /// this operation trivial.
        /// </remarks>
        public void HalvenDistance()
        {
            distance = (int) Math.Ceiling(0.5 * distance);
        }

        public GenreTagConnection(string got1, string got2, int distance)
        {
            this.GoT1 = got1;
            this.GoT2 = got2;
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
            if (got1 == this.GoT1)
                if (got2 == this.GoT2)
                    return true;
            return false;
        }

        public bool SameArrow(GenreTagConnection gtc)
        {
            return SameArrow(gtc.GoT1, gtc.GoT2);
        }

        public bool SameConnection(GenreTagConnection gtc)
        {
            return SameConnection(gtc.GoT1, gtc.GoT2);
        }
    }
}
