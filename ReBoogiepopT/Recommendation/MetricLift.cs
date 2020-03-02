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

    public class MetricLiftAggregation
    {
        public Media Media { get; }

        public int InnerProductWithBase { get; }

        public MetricLiftAggregation(Media media, int innerProductWithBase)
        {
            Media = media;
            InnerProductWithBase = innerProductWithBase;
        }
    }
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
        public MetricLiftMode MetricLiftMode { get; set; }

        /// <summary>
        /// MediaId of the apt media for applying metriclift.
        /// </summary>
        /// <remarks>One may change the apt media in an instance of metriclift.</remarks>
        public int AptMediaId { get; set; }

        /// <summary>
        /// The apt media itself.
        /// </summary>
        private Media aptMedia;

        /// <summary>
        /// Fetches the apt media and assigns it to the designated field.
        /// </summary>
        /// <returns></returns>
        private async Task GetAptMedia()
        {
            aptMedia = await Operation.MediaById(AptMediaId);
        }

        /// <summary>
        /// Assign the apt media id and the apt media to the designated fields.
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns></returns>
        public async Task ChangeAptMedia(int mediaId)
        {
            AptMediaId = mediaId;
            await GetAptMedia();
        }

        /// <summary>
        /// The metric to be used for this instance of metriclift.
        /// </summary>
        /// <remarks>Keep an eye on the mode.</remarks>
        private readonly Metric metric;

        public void ChangeMetricMode(MetricMode mode)
        {
            metric.Mode = mode;
        }

        /// <summary>
        /// Base difference vector.
        /// </summary>
        private List<GenreTagConnection> baseDifferenceVector;

        /// <summary>
        /// Defines the base difference vector.
        /// </summary>
        private async Task DefineBase()
        {
            Media baseMedia1 = await Operation.MediaById(baseMediaId1);
            Media baseMedia2 = await Operation.MediaById(baseMediaId2);

            baseDifferenceVector = CompleteDifferenceVector(baseMedia1, baseMedia2);
        }

        /// <summary>
        /// List of media that must be considered using metriclift.
        /// </summary>
        /// <remarks>
        /// May be changed within an instance of metriclift.
        /// </remarks>
        public List<Media> MediaToConsider { get; set; }

        /// <summary>
        /// Applies metriclift to the media to consider.
        /// </summary>
        /// <returns>The list of the media tagged with the inner product with base.</returns>
        public MetricLiftAggregation ApplyMetricLift()
        {
            throw new NotImplementedException();
        }

        public MetricLift(int baseMediaId1, int baseMediaId2, MetricLiftMode mode, Metric metric)
        {
            this.baseMediaId1 = baseMediaId1;
            this.baseMediaId2 = baseMediaId2;
            this.MetricLiftMode = mode;
            this.metric = metric;
        }

        public MetricLift(int baseMediaId1, int baseMediaId2, int aptMediaId, MetricLiftMode mode, Metric metric)
            : this(baseMediaId1, baseMediaId2, mode, metric)
        {
            AptMediaId = aptMediaId;
        }

        /// <summary>
        /// Calculates the complete difference vector between the two media.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        private List<GenreTagConnection> CompleteDifferenceVector(Media m1, Media m2)
        {
            switch (MetricLiftMode)
            {
                case MetricLiftMode.Arrow:
                    return CompleteDifferenceVectorArrow(m1, m2);
                case MetricLiftMode.Connection:
                    return CompleteDifferenceVectorConnection(m1, m2);
                default:
                    throw new ArgumentOutOfRangeException(nameof(MetricLiftMode), "MetricLiftMode passed is invalid!");
            }
        }

        /// <summary>
        /// Calculates the distance of every arrow from a genre or tag of m1 to a genre or tag of m2.
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>A vector with the distance of each arrow in a component.</returns>
        private List<GenreTagConnection> CompleteDifferenceVectorArrow(Media m1, Media m2)
        {
            List<GenreTagConnection> cdv = new List<GenreTagConnection>((m1.Genres.Count + m1.Tags.Count)
                * (m2.Genres.Count + m2.Tags.Count));

            // Add all arrows from m1 genres to m2 genres.
            foreach (string m1g in m1.Genres)
            {
                foreach (string m2g in m2.Genres)
                {
                    cdv.Add(new GenreTagConnection(m1g, m2g, metric.Distance(m1g, m2g)));
                }
            }

            // Add all arrows from m1 genres to m2 tags.
            foreach (string m1g in m1.Genres)
            {
                foreach (MediaTag m2t in m2.Tags)
                {
                    cdv.Add(new GenreTagConnection(m1g, m2t.Name, metric.Distance(m1g, m2t.Name)));
                }
            }

            // Add all arrows from m1 tags to m2 genres.
            foreach (MediaTag m1t in m1.Tags)
            {
                foreach (string m2g in m2.Genres)
                {
                    cdv.Add(new GenreTagConnection(m1t.Name, m2g, metric.Distance(m1t.Name, m2g)));
                }
            }

            // Add all arrows from m1 tags to m2 tags.
            foreach (MediaTag m1t in m1.Tags)
            {
                foreach (MediaTag m2t in m2.Tags)
                {
                    cdv.Add(new GenreTagConnection(m1t.Name, m2t.Name, metric.Distance(m1t.Name, m2t.Name)));
                }
            }

            return cdv;
        }

        /// <summary>
        /// Calculates the distance of every connection between a genre or tag from m1 and a genre or tag of m2.
        /// </summary>
        /// <param name="m1">Media 1</param>
        /// <param name="m2">Media 2</param>
        /// <returns>A vector with the distance of each connection in a component.</returns>
        /// <remarks>
        /// 1. Differs from arrow in that the direction is irrelevant, though if an arrow appears in both directions the distance is
        ///    halved (and round up).
        /// 2. Theorem: Arrow A_1 -> B_2 exists explicitly in the collection of reversed arrows, that is arrows of the form C_2 -> D_1.
        ///             <=> Arrows A_1 -> B_2 and B_1 -> A_2 both exist explicitly.
        ///    Notational remark: subscript stands for the media and the symbol in front for the tag or genre name. So A_1 means tag
        ///    or genre A from media 1.
        ///    
        ///    Proof: =>: By assumption A_1 -> B_2 exists explicitly in the collection of reversed arrows, so there exists an arrow
        ///    A_2 -> B_1. But this implies B is a genre or tag of media 1 and A is a genre or tag of media 2 so the arrow
        ///    B_1 -> A_2 exists in the collection or arrows from media 1 to media 2.
        ///           <=: Assume Arrows A_1 -> B_2 and B_1 -> A_2 both exist explicitly. Then A and B are both genre or tags of media 1
        ///    and media 2. Hence the arrow A_2 -> B_1 exists in the collectrion of reversed arrows.
        /// 3. Since the arrow in the other direction exists explicitly if the reversed arrow exists (by the above theorem)
        ///    it needs to be found and removed anyway.
        /// 4. Moreover since the existence of the reversed arrow in the initial direction implies the existence of the reversed arrow
        ///    in the collection of reversed arrows it is not necessary to work with the collection of reversed arrows. In fact it's less
        ///    efficient since there would be a list traversal to find the arrow in the collection of reversed arrows and there would need
        ///    to be a traversal to remove the reversed arrow, whoms existence is assured by the theorem above, from the initial collection
        ///    of arrows. One would rather look for the reversed arrow in the initial collection of arrows, remove it and halven the
        ///    distance of the remaining connection!
        /// </remarks>
        private List<GenreTagConnection> CompleteDifferenceVectorConnection(Media m1, Media m2)
        {
            List<GenreTagConnection> cdv = CompleteDifferenceVectorArrow(m1, m2);

            // New list created, since rather not mend the list that's being looped over.
            List<GenreTagConnection> cdvConnection = new List<GenreTagConnection>(cdv.Count);

            foreach (GenreTagConnection gtc in cdv)
            {
                GenreTagConnection alreadyExistingSameConnection = cdvConnection.Find(cdvConnectionGtc => cdvConnectionGtc.SameConnection(gtc));

                // The connection does already exist.
                if (alreadyExistingSameConnection != null)
                    alreadyExistingSameConnection.HalvenDistance();


                // The connection does not already exist.
                else
                    cdvConnection.Add(gtc);
            }

            return cdvConnection;
        }

        /// <summary>
        /// Aligns the dimensions, that is connections or arrows, of dv with the base differences vector (discarding any other dimensions)
        /// then taking the standard inner product on R^k with k the amount of dimensions of base.
        /// </summary>
        /// <param name="dv"></param>
        /// <returns>Inner product on R^k with dv restricted to the dimensions of base.</returns>
        private int InnerProductWithBase(List<GenreTagConnection> dv)
        {
            switch (MetricLiftMode)
            {
                case MetricLiftMode.Arrow:
                    return InnerProductWithBaseArrow(dv);
                case MetricLiftMode.Connection:
                    return InnerProductWithBaseConnection(dv);
                default:
                    throw new ArgumentOutOfRangeException(nameof(MetricLiftMode), "MetricLiftMode passed is invalid!");
            }
        }

        /// <summary>
        /// Aligns the arrows of dv with the base differences vector (discarding any other arrows)
        /// then taking the standard inner product on R^k with k the amount of arrows of base.
        /// </summary>
        /// <param name="dv"></param>
        /// <returns>Inner product on R^k with dv restricted to the dimensions of base.</returns>
        /// <remarks>
        /// Any arrows that don't exist in dv are taken as 0 and hence that term does not contribut anything to the
        /// inner product.
        /// </remarks>
        private int InnerProductWithBaseArrow(List<GenreTagConnection> dv)
        {
            int sum = 0;
            foreach (GenreTagConnection baseGtc in baseDifferenceVector)
            {
                GenreTagConnection cBaseGtcArrowInDV = dv.Find(cdvGtc => cdvGtc.SameArrow(baseGtc));

                // If the current arrow being considered in base exists in dv.
                if (cBaseGtcArrowInDV != null)
                    sum += cBaseGtcArrowInDV.Distance * baseGtc.Distance;

                // The arrow being considered does not exist in dv.
                else
                    continue;
            }
            return sum;
        }

        private int InnerProductWithBaseConnection(List<GenreTagConnection> dv)
        {
            int sum = 0;
            foreach (GenreTagConnection baseGtc in baseDifferenceVector)
            {
                GenreTagConnection cBaseGtcConnectionInDV = dv.Find(cdvGtc => cdvGtc.SameConnection(baseGtc));

                // The current base connection being considered exists in dv.
                if (cBaseGtcConnectionInDV != null)
                    sum += cBaseGtcConnectionInDV.Distance * baseGtc.Distance;

                // The current base connection being considered does not exist in dv.
                else
                    continue;
            }
            return sum;
        }
    }
}
