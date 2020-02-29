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
    public class MetricTests
    {
        // [TestMethod]
        public async Task CountMetric_GenreGenre_GivesValidResult()
        {
            // Arrange
            GenreAndTagStatInfo statInfo = new GenreAndTagStatInfo("Drens5");
            await statInfo.Initialize();

            Metric metric = new Metric(statInfo, MetricMode.Count);
            // Act
            int actualDistance = metric.Distance("Female Protagonist", "Primarily Female Cast");

            // Assert
            // This is dependent on the user so check first if the assert values are still correct.
            Assert.AreEqual<int>(2, actualDistance);
        }

        // [TestMethod]
        public async Task CountMetric_InvalidTagOrGenre_ThrowsRightException()
        {
            // Arrange
            GenreAndTagStatInfo statInfo = new GenreAndTagStatInfo("Drens5");
            await statInfo.Initialize();

            Metric metric = new Metric(statInfo, MetricMode.Count);
            // Act

            // Assert
            Assert.ThrowsException<InvalidGenreOrTagException>(() =>
            {
                metric.Distance("invalid", "Female Protagonist");
            });

            Assert.ThrowsException<InvalidGenreOrTagException>(() =>
            {
                metric.Distance("Female Protagonist", "invalid");
            });

            Assert.ThrowsException<InvalidGenreOrTagException>(() =>
            {
                metric.Distance("Comedy", "invalid");
            });

            Assert.ThrowsException<InvalidGenreOrTagException>(() =>
            {
                metric.Distance("invalid", "Comedy");
            });
        }
    }
}
