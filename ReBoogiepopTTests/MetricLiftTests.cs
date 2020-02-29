using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation;
using ReBoogiepopT.Recommendation.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopTTests
{
    [TestClass]
    public class MetricLiftTests
    {
        // [TestMethod]
        public async Task CompleteDifferenceVectorArrow_CountMetric_GivesValidResult()
        {
            // Arrange
            GenreAndTagStatInfo statInfo = new GenreAndTagStatInfo("Drens5");
            await statInfo.Initialize();

            Metric metric = new Metric(statInfo, MetricMode.Count);

            MetricLift metricLift = new MetricLift(104051, 20714, MetricLiftMode.Arrow, metric);

            // Act
            Media media1 = await Operation.MediaById(104051);
            Media media2 = await Operation.MediaById(20714);

            List<GenreTagConnection> cdv = metricLift.CompleteDifferenceVectorArrow(media1, media2);

            // Assert, by break point.
        }

        // [TestMethod]
        public async Task CompleteDifferenceVectorConnection_CountMetric_GivesValidResult()
        {
            // Arrange
            GenreAndTagStatInfo statInfo = new GenreAndTagStatInfo("Drens5");
            await statInfo.Initialize();

            Metric metric = new Metric(statInfo, MetricMode.Count);

            MetricLift metricLift = new MetricLift(104051, 20714, MetricLiftMode.Connection, metric);

            // Act
            Media media1 = await Operation.MediaById(104051);
            Media media2 = await Operation.MediaById(20714);

            List<GenreTagConnection> cdv = metricLift.CompleteDifferenceVectorConnection(media1, media2);

            // Assert, by break point.
        }
    }
}
