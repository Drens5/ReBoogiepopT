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
    public enum MetricLiftMode { Connection, Arrow }

    /// <summary>
    /// Recommendation method which combines elements from Metric and VectorLift to provide a different method for
    /// selecting / aggregating / sorting anime.
    /// One prescribes an arrow or connection between two anime, this will define a base (difference vector).
    /// This base is defined in terms of all the arrows (in the same direction) or connections between genres and tags of those media.
    /// Each dimension corresponds to an arrow or connection and has value of the distance between the gernes or tags in question.
    /// One also specifies an apt anime A.
    /// The goal of metriclift is now to find an anime B so that the difference vector between A and B is close (in terms of the
    /// inner product on R^k) to the base difference vector.
    /// </summary>
    /// <remarks>Funnily MetricLift came first but upon dissecting its parts Metric and VectorLift were isolated as
    /// seperate recommendation methods!</remarks>
    public class MetricLift
    {
        /// <summary>
        /// MediaId of media 1 in the base.
        /// </summary>
        private readonly int baseMediaId1;

        /// <summary>
        /// MediaId of media 2 in the base.
        /// </summary>
        private readonly int baseMediaId2;

        /// <summary>
        /// Mode of metric lift.
        /// The arrow goes from 1 -> 2.
        /// </summary>
        private readonly MetricLiftMode mode;

        /// <summary>
        /// MediaId of the apt media for applying metriclift.
        /// </summary>
        /// <remarks>One may change the apt media in an instance of metriclift.</remarks>
        public int AptMediaId { get; set; }

        /// <summary>
        /// The apt media itself.
        /// </summary>
        private Media aptMedia;
    }
}
