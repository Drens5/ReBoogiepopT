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
    public class ActivityInjectTests
    {
        // [TestMethod]
        public async Task RunActivityInject_ForSingleInjectMedia_WithAllOptionsMinimallySpecified_GivesValidResult()
        {
            // Arrange
            List<int> injectMedia = new List<int>();
            injectMedia.Add(15227);
            User pAuth = await Operation.UserFavoritesStatistics("Drens5");
            List<CoupledTag> cTags = new List<CoupledTag>() { new CoupledTag("Historical") };

            ActivityInject testActivityInject = new ActivityInject(injectMedia, 50, ActivityInject.ListActivityStatusSelection.All, pAuth, cTags);

            // Act
            List<CountMedia> mediaInQuestion = await testActivityInject.RunActivityInject();
            List<CountMedia> mediaInQuestionRaw = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.LocalPopularity);
            List<CountMedia> mediaInQuestionLocalPopularitySorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.MeanScore);
            List<CountMedia> mediaInQuestionMeanScoreSorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.GlobalPopularity);
            List<CountMedia> mediaInQuestionGlobalPopularitySorted = mediaInQuestion;

            // Assert, by break point.
        }


        // [TestMethod]
        public async Task RunActivityInject_ForMutliInjectMedia_CompletedOnly_WithAllOptionsVariedSpecified_ComedyFocus_GivesValidResult()
        {
            // Arrange
            List<int> injectMedia = new List<int>() { 10165, 101001, 10495, 21088 };
            User pAuth = await Operation.UserFavoritesStatistics("Drens5");
            List<CoupledTag> cTags = new List<CoupledTag>() { new CoupledTag(new List<string>() { "Slapstick", "Parody" }),
                new CoupledTag(new List<string>() { "Meta", "Episodic", "Ensemble Cast", "Primarily Female Cast" }), new CoupledTag(new List<string>()
                { "Surreal Comedy", "Satire" })}; // Only 46. Previous (one commented below) had ~150. Also took much longer? Looks pretty good.

            // List<CoupledTag> cTags = new List<CoupledTag>() { new CoupledTag(new List<string>() { "Slapstick", "Surreal Comedy", "Parody" }), 
            //     new CoupledTag(new List<string>() { "Meta", "Episodic", "Ensemble Cast", "Primarily Female Cast" })};

            ActivityInject testActivityInject = new ActivityInject(injectMedia, 50, ActivityInject.ListActivityStatusSelection.CompletedOnly, pAuth, cTags);

            // Act
            List<CountMedia> mediaInQuestion = await testActivityInject.RunActivityInject();
            List<CountMedia> mediaInQuestionRaw = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.LocalPopularity);
            List<CountMedia> mediaInQuestionLocalPopularitySorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.MeanScore);
            List<CountMedia> mediaInQuestionMeanScoreSorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.GlobalPopularity);
            List<CountMedia> mediaInQuestionGlobalPopularitySorted = mediaInQuestion;

            // Assert, by break point.
        }


        // [TestMethod]
        public async Task RunActivityInject_ForMutliInjectMedia_CompletedOnly_WithAllOptionsVariedSpecified_ShinsekaiFocus_GivesValidResult()
        {
            // Arrange
            List<int> injectMedia = new List<int>() { 13125 };
            User pAuth = await Operation.UserFavoritesStatistics("Drens5");
            List<CoupledTag> cTags = new List<CoupledTag>() { new CoupledTag(new List<string>() { "Tragedy" }),
                new CoupledTag(new List<string>() { "Dystopian", "Anti-Hero", "Lost Civilization", "Philosophy", "History" }), new CoupledTag(new List<string>()
                { "Revenge", "War" })};

            ActivityInject testActivityInject = new ActivityInject(injectMedia, 50, ActivityInject.ListActivityStatusSelection.CompletedOnly, pAuth, cTags);

            // Act
            List<CountMedia> mediaInQuestion = await testActivityInject.RunActivityInject();
            List<CountMedia> mediaInQuestionRaw = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.LocalPopularity);
            List<CountMedia> mediaInQuestionLocalPopularitySorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.MeanScore);
            List<CountMedia> mediaInQuestionMeanScoreSorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.GlobalPopularity);
            List<CountMedia> mediaInQuestionGlobalPopularitySorted = mediaInQuestion;

            // Assert, by break point. Since the above are reference types, put the breakpoint after each sort to see that sort in work.
        }


        // [TestMethod]
        public async Task RunActivityInject_ForSingleInjectMedia_CompletedOnly_WithoutTags_YoujoSenkiFocus_GivesValidResult()
        {
            // Arrange
            List<int> injectMedia = new List<int>() { 21613 };
            User pAuth = await Operation.UserFavoritesStatistics("Drens5");

            ActivityInject testActivityInject = new ActivityInject(injectMedia, 50, ActivityInject.ListActivityStatusSelection.CompletedOnly, pAuth);

            // Act
            List<CountMedia> mediaInQuestion = await testActivityInject.RunActivityInject();
            List<CountMedia> mediaInQuestionRaw = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.LocalPopularity);
            List<CountMedia> mediaInQuestionLocalPopularitySorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.MeanScore);
            List<CountMedia> mediaInQuestionMeanScoreSorted = mediaInQuestion;

            mediaInQuestion.Sort(Aggregation.GlobalPopularity);
            List<CountMedia> mediaInQuestionGlobalPopularitySorted = mediaInQuestion;

            // Assert, by break point. Since the above are reference types, put the breakpoint after each sort to see that sort in work.
        }
    }
}
