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
            GenreAndTagStatInfo statInfoQuick = new GenreAndTagStatInfo("Drens5", StatInfoMode.Quick);
            GenreAndTagStatInfo statInfoSophisticated = new GenreAndTagStatInfo("Drens5", StatInfoMode.Sophisticated);
            GenreAndTagStatInfo statInfoFavourites = new GenreAndTagStatInfo("Drens5", StatInfoMode.Favourites);

            await statInfoQuick.Initialize();
            await statInfoSophisticated.Initialize();
            await statInfoFavourites.Initialize();
            // Act

            // Assert, by break point.
        }
    }
}