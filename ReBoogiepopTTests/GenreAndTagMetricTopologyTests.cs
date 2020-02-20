using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation.MetricLift;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopTTests
{
    [TestClass]
    public class GenreAndTagMetricTopologyTests
    {
        // [TestMethod]
        public async Task Initialization_GivesValidResult()
        {
            // Arrange
            GenreAndTagMetricTopology topology = new GenreAndTagMetricTopology("Drens5");
            await topology.Initialize();
            // Act

            // Assert, by break point.
        }
    }
}