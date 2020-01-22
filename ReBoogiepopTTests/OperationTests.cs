using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
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
        private int kannaPoggersId = 387582;

        /// <summary>
        /// Single query test for PageListActivityInfoLastPage method.
        /// </summary>
        /// <remarks>Since this queries the real Api, the correct value to assert by may change over time.</remarks>
        //[TestMethod]
        public async Task PageListActivityInfoLastPage_ForSingleQuery_GivesValidLastPage()
        {
            // Arrange

            // Act
            int actualLastPage = await Operation.PageListActivityInfoLastPage(testMediaId);

            // Assert
            Assert.AreEqual<int>(expectedLastPageToTestMediaId, actualLastPage);
        }

        /// <summary>
        /// Test to see if rate limit exceeding is handled properly.
        /// </summary>
        /// <remarks>Rate limit is never reached because a single request (as done now) takes about 0.75 seconds.</remarks>
        // [TestMethod]
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

        /// <summary>
        /// Verify the proper behaviour of PageListActivityInfo.
        /// </summary>
        // [TestMethod]
        public async Task PageListActivityInfo_ForSingleQuery_GivesValidPage()
        {
            // Arrange

            // Act
            Page page = await Operation.PageListActivityInfo(expectedLastPageToTestMediaId, testMediaId);

            // Assert, since the values change all the time set a break point at the end of this function to check the values by eye.
        }

        /// <summary>
        /// Verify the proper behaviour of UserMediaListDownToMediaList.
        /// </summary>
        // [TestMethod]
        public async Task UserMediaListDownToMediaList_ForSingleQuery_GivesValidList()
        {
            // Arrange

            // Act
            List<MediaList> fullMediaList = await Operation.UserMediaListDownToMediaList(kannaPoggersId);

            // Assert, set breakpoint below.
        }
    }
}
