using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReBoogiepopT.ApiCommunication;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using ReBoogiepopT.Recommendation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReBoogiepopTTests
{
    [TestClass]
    public class GenreAndTagStatInfoTests
    {
        // [TestMethod]
        public async Task Initialization_GivesValidResult()
        {
            // Arrange
            GenreAndTagStatInfo statInfo = new GenreAndTagStatInfo("Drens5", StatInfoMode.Quick);
            await statInfo.Initialize();
            // Act

            // Assert, by break point.
        }
    }
}