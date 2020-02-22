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
    /// Recommendation method which combines elements from Metric and VectorLift to provide a different method for
    /// selecting / aggregating / sorting anime.
    /// </summary>
    /// <remarks>Funnily MetricLift came first but upon dissecting its parts Metric and VectorLift were isolated as
    /// seperate recommendation methods!</remarks>
    public class MetricLift
    {
    }
}
