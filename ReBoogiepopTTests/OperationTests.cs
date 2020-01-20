using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ReBoogiepopT.ApiCommunication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopTTests
{
    [TestClass]
    public class OperationTests
    {
        // Keep in one place since expectedLastPageToTestMediaId may change, since the tests query the actual Api.
        private int testMediaId = 15227;
        private int expectedLastPageToTestMediaId = 92;

        /// <summary>
        /// Single query test for PageListActivityInfoLastPage method.
        /// </summary>
        /// <remarks>Since this queries the real Api, the correct value to assert by may change over time.</remarks>
        [TestMethod]
        public async Task PageListActivityInfoLastPage_ForSingleQuery_GivesValidLastPage()
        {
            // Arrange

            // Act
            int actualLastPage = await Operation.PageListActivityInfoLastPage(testMediaId);

            // Assert
            Assert.AreEqual<int>(expectedLastPageToTestMediaId, actualLastPage);
        }

        [TestMethod]
        public async Task PageListActivityInfoLastPage_ExceedingRateLimit_GivesValidLastPage()
        {
            // Arrange

            // Act

            // Exceed the Rate Limit.
            for(int i = 0; i < 100; i++)
            {
                await Operation.PageListActivityInfoLastPage(10165);
            }

            int actualLastPage = await Operation.PageListActivityInfoLastPage(testMediaId);

            // Assert
            Assert.AreEqual<int>(expectedLastPageToTestMediaId, actualLastPage);
        }
    }
}
