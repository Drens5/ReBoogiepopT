using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReBoogiepopT.ApiCommunication.AnilistDatatypes;
using System.Diagnostics;

namespace ReBoogiepopTTests
{
    [TestClass]
    public class JsonDeserializationTests
    {
        [TestMethod]
        public void User_GeneralResponse_Deserializes()
        {
            // Arrange
            string userJsonResponse = @"{
                ""data"": {
                    ""User"": {
                                ""id"": 137485,
                        ""siteUrl"": ""https://anilist.co/user/137485"",
                        ""favourites"": {
                                    ""anime"": {
                                        ""nodes"": [
                                            {
                                ""id"": 10165,
                                            ""title"": {
                                ""english"": ""Nichijou - My Ordinary Life"",
                                                ""native"": ""日常"",
                                                ""romaji"": ""Nichijou""
                                }
                },
                            {
                                ""id"": 15227,
                                ""title"": {
                                ""english"": ""In This Corner of the World"",
                                ""native"": ""この世界の片隅に"",
                                ""romaji"": ""Kono Sekai no Katasumi ni""
                                }
                            },
                            {
                                ""id"": 99426,
                                ""title"": {
                                ""english"": ""A Place Further Than the Universe"",
                                ""native"": ""宇宙よりも遠い場所"",
                                ""romaji"": ""Sora yori mo Tooi Basho""
                                }
                            },
                            {
                                ""id"": 232,
                                ""title"": {
                                ""english"": ""Cardcaptor Sakura"",
                                ""native"": ""カードキャプターさくら"",
                                ""romaji"": ""Cardcaptor Sakura""
                                }
                            },
                            {
                                ""id"": 20766,
                                ""title"": {
                                ""english"": null,
                                ""native"": ""ラブライブ！The School Idol Movie"",
                                ""romaji"": ""Love Live! The School Idol Movie""
                                }
                            },
                            {
                                ""id"": 13125,
                                ""title"": {
                                ""english"": ""From the New World"",
                                ""native"": ""新世界より"",
                                ""romaji"": ""Shinsekai yori""
                                }
                            },
                            {
                                ""id"": 21858,
                                ""title"": {
                                ""english"": null,
                                ""native"": ""リトルウィッチアカデミア (TV)"",
                                ""romaji"": ""Little Witch Academia (TV)""
                                }
                            },
                            {
                                ""id"": 21673,
                                ""title"": {
                                ""english"": ""Symphogear XV"",
                                ""native"": ""戦姫絶唱シンフォギアＸＶ"",
                                ""romaji"": ""Senki Zesshou Symphogear XV""
                                }
                            }
                            ]
                        }
                        },
                        ""statistics"": {
                        ""anime"": {
                            ""count"": 306,
                            ""minutesWatched"": 182649,
                            ""genres"": [
                            {
                                ""count"": 127,
                                ""minutesWatched"": 122049,
                                ""genre"": ""Comedy""
                            },
                            {
                                ""count"": 70,
                                ""minutesWatched"": 106813,
                                ""genre"": ""Adventure""
                            },
                            {
                                ""count"": 113,
                                ""minutesWatched"": 81420,
                                ""genre"": ""Action""
                            },
                            {
                                ""count"": 68,
                                ""minutesWatched"": 52858,
                                ""genre"": ""Fantasy""
                            },
                            {
                                ""count"": 58,
                                ""minutesWatched"": 56514,
                                ""genre"": ""Mystery""
                            },
                            {
                                ""count"": 81,
                                ""minutesWatched"": 39380,
                                ""genre"": ""Drama""
                            },
                            {
                                ""count"": 43,
                                ""minutesWatched"": 54256,
                                ""genre"": ""Psychological""
                            },
                            {
                                ""count"": 82,
                                ""minutesWatched"": 18387,
                                ""genre"": ""Slice of Life""
                            },
                            {
                                ""count"": 55,
                                ""minutesWatched"": 18709,
                                ""genre"": ""Supernatural""
                            },
                            {
                                ""count"": 56,
                                ""minutesWatched"": 11637,
                                ""genre"": ""Romance""
                            },
                            {
                                ""count"": 48,
                                ""minutesWatched"": 18402,
                                ""genre"": ""Sci-Fi""
                            },
                            {
                                ""count"": 23,
                                ""minutesWatched"": 14698,
                                ""genre"": ""Sports""
                            },
                            {
                                ""count"": 30,
                                ""minutesWatched"": 6627,
                                ""genre"": ""Music""
                            },
                            {
                                ""count"": 25,
                                ""minutesWatched"": 7661,
                                ""genre"": ""Horror""
                            },
                            {
                                ""count"": 23,
                                ""minutesWatched"": 4545,
                                ""genre"": ""Ecchi""
                            },
                            {
                                ""count"": 17,
                                ""minutesWatched"": 5641,
                                ""genre"": ""Thriller""
                            },
                            {
                                ""count"": 15,
                                ""minutesWatched"": 4285,
                                ""genre"": ""Mahou Shoujo""
                            },
                            {
                                ""count"": 11,
                                ""minutesWatched"": 482,
                                ""genre"": ""Hentai""
                            },
                            {
                                ""count"": 5,
                                ""minutesWatched"": 3127,
                                ""genre"": ""Mecha""
                            }
                            ],
                            ""tags"": [
                            {
                                ""count"": 71,
                                ""minutesWatched"": 111697,
                                ""tag"": {
                                ""id"": 82,
                                ""name"": ""Male Protagonist"",
                                ""description"": ""Main character is male."",
                                ""category"": ""Cast-Main Cast""
                                }
                            },
                            {
                                ""count"": 44,
                                ""minutesWatched"": 106130,
                                ""tag"": {
                                ""id"": 56,
                                ""name"": ""Shounen"",
                                ""description"": ""Target demographic is teenage and young adult males."",
                                ""category"": ""Demographic""
                                }
                            },
                            {
                                ""count"": 96,
                                ""minutesWatched"": 29329,
                                ""tag"": {
                                ""id"": 98,
                                ""name"": ""Female Protagonist"",
                                ""description"": ""Main character is female."",
                                ""category"": ""Cast-Main Cast""
                                }
                            },
                            {
                                ""count"": 94,
                                ""minutesWatched"": 29126,
                                ""tag"": {
                                ""id"": 86,
                                ""name"": ""Primarily Female Cast"",
                                ""description"": ""Main cast is mostly composed of female characters."",
                                ""category"": ""Cast-Main Cast""
                                }
                            },
                            {
                                ""count"": 43,
                                ""minutesWatched"": 58322,
                                ""tag"": {
                                ""id"": 66,
                                ""name"": ""Super Power"",
                                ""description"": ""Prominently features characters with special abilities that allow them to do what would normally be physically or logically impossible."",
                                ""category"": ""Theme-Fantasy""
                                }
                            },
                            {
                                ""count"": 51,
                                ""minutesWatched"": 34720,
                                ""tag"": {
                                ""id"": 85,
                                ""name"": ""Tragedy"",
                                ""description"": ""Centers around tragic events and unhappy endings."",
                                ""category"": ""Theme-Drama""
                                }
                            },
                            {
                                ""count"": 12,
                                ""minutesWatched"": 60534,
                                ""tag"": {
                                ""id"": 648,
                                ""name"": ""Crime"",
                                ""description"": ""Centers around unlawful activities punishable by the state or other authority."",
                                ""category"": ""Theme-Other""
                                }
                            },
                            {
                                ""count"": 67,
                                ""minutesWatched"": 19229,
                                ""tag"": {
                                ""id"": 46,
                                ""name"": ""School"",
                                ""description"": ""Partly or completely set in a primary or secondary educational institution."",
                                ""category"": ""Setting-Scene""
                                }
                            },
                            {
                                ""count"": 8,
                                ""minutesWatched"": 59265,
                                ""tag"": {
                                ""id"": 310,
                                ""name"": ""Espionage"",
                                ""description"": ""Prominently features characters infiltrating an organization in order to steal sensitive information."",
                                ""category"": ""Theme-Action""
                                }
                            },
                            {
                                ""count"": 6,
                                ""minutesWatched"": 56727,
                                ""tag"": {
                                ""id"": 456,
                                ""name"": ""Conspiracy"",
                                ""description"": ""Contains one or more factions controlling or attempting to control the world from the shadows."",
                                ""category"": ""Theme-Drama""
                                }
                            },
                            {
                                ""count"": 19,
                                ""minutesWatched"": 48200,
                                ""tag"": {
                                ""id"": 193,
                                ""name"": ""Episodic"",
                                ""description"": ""Features story arcs that are loosely tied or lack an overarching plot."",
                                ""category"": ""Technical""
                                }
                            },
                            {
                                ""count"": 57,
                                ""minutesWatched"": 14742,
                                ""tag"": {
                                ""id"": 92,
                                ""name"": ""Cute Girls Doing Cute Things"",
                                ""description"": ""Centers around, well, cute girls doing cute things."",
                                ""category"": ""Theme-Slice of Life""
                                }
                            },
                            {
                                ""count"": 10,
                                ""minutesWatched"": 43970,
                                ""tag"": {
                                ""id"": 40,
                                ""name"": ""Police"",
                                ""description"": ""Centers around the life and activities of law enforcement officers."",
                                ""category"": ""Theme-Other-Organisations""
                                }
                            },
                            {
                                ""count"": 7,
                                ""minutesWatched"": 42788,
                                ""tag"": {
                                ""id"": 488,
                                ""name"": ""Age Regression"",
                                ""description"": ""Prominently features a character who was returned to a younger state."",
                                ""category"": ""Cast-Traits""
                                }
                            },
                            {
                                ""count"": 42,
                                ""minutesWatched"": 20683,
                                ""tag"": {
                                ""id"": 321,
                                ""name"": ""Urban Fantasy"",
                                ""description"": ""Set in a world similar to the real world, but with the existence of magic or other supernatural elements."",
                                ""category"": ""Setting-Universe""
                                }
                            },
                            {
                                ""count"": 3,
                                ""minutesWatched"": 41284,
                                ""tag"": {
                                ""id"": 158,
                                ""name"": ""Crossover"",
                                ""description"": ""Centers around the placement of two or more otherwise discrete fictional characters, settings, or universes into the context of a single story."",
                                ""category"": ""Theme-Other""
                                }
                            },
                            {
                                ""count"": 22,
                                ""minutesWatched"": 30768,
                                ""tag"": {
                                ""id"": 99,
                                ""name"": ""Henshin"",
                                ""description"": ""Prominently features character or costume transformations which often grant special abilities."",
                                ""category"": ""Theme-Fantasy""
                                }
                            },
                            {
                                ""count"": 38,
                                ""minutesWatched"": 16751,
                                ""tag"": {
                                ""id"": 29,
                                ""name"": ""Magic"",
                                ""description"": ""Prominently features magical elements or the use of magic."",
                                ""category"": ""Theme-Fantasy""
                                }
                            },
                            {
                                ""count"": 22,
                                ""minutesWatched"": 23259,
                                ""tag"": {
                                ""id"": 105,
                                ""name"": ""Ensemble Cast"",
                                ""description"": ""Features a large cast of characters with (almost) equal screen time and importance to the plot."",
                                ""category"": ""Cast-Main Cast""
                                }
                            },
                            {
                                ""count"": 21,
                                ""minutesWatched"": 22921,
                                ""tag"": {
                                ""id"": 43,
                                ""name"": ""Swordplay"",
                                ""description"": ""Prominently features the use of swords in combat."",
                                ""category"": ""Theme-Action""
                                }
                            },
                            {
                                ""count"": 13,
                                ""minutesWatched"": 26753,
                                ""tag"": {
                                ""id"": 111,
                                ""name"": ""War"",
                                ""description"": ""Partly or completely set during wartime."",
                                ""category"": ""Theme-Other""
                                }
                            },
                            {
                                ""count"": 37,
                                ""minutesWatched"": 9069,
                                ""tag"": {
                                ""id"": 50,
                                ""name"": ""Seinen"",
                                ""description"": ""Target demographic is adult males."",
                                ""category"": ""Demographic""
                                }
                            },
                            {
                                ""count"": 27,
                                ""minutesWatched"": 10904,
                                ""tag"": {
                                ""id"": 102,
                                ""name"": ""Coming of Age"",
                                ""description"": ""Centers around a character's transition from childhood to adulthood."",
                                ""category"": ""Theme-Drama""
                                }
                            },
                            {
                                ""count"": 17,
                                ""minutesWatched"": 19067,
                                ""tag"": {
                                ""id"": 109,
                                ""name"": ""Primarily Adult Cast"",
                                ""description"": ""Main cast is mostly composed of characters above a high school age."",
                                ""category"": ""Cast-Main Cast""
                                }
                            },
                            {
                                ""count"": 32,
                                ""minutesWatched"": 8023,
                                ""tag"": {
                                ""id"": 76,
                                ""name"": ""Yuri"",
                                ""description"": ""Prominently features romance between two females, not inherently sexual. Also known as Girls' Love."",
                                ""category"": ""Theme-Romance""
                                }
                            },
                            {
                                ""count"": 13,
                                ""minutesWatched"": 20778,
                                ""tag"": {
                                ""id"": 96,
                                ""name"": ""Time Manipulation"",
                                ""description"": ""Prominently features time-traveling or other time-warping phenomena."",
                                ""category"": ""Theme-Sci-Fi""
                                }
                            },
                            {
                                ""count"": 5,
                                ""minutesWatched"": 21785,
                                ""tag"": {
                                ""id"": 326,
                                ""name"": ""Cultivation"",
                                ""description"": ""Features characters using training, often martial arts-related, and other special methods to cultivate life force and gain strength or immortality."",
                                ""category"": ""Theme-Fantasy""
                                }
                            },
                            {
                                ""count"": 18,
                                ""minutesWatched"": 16390,
                                ""tag"": {
                                ""id"": 252,
                                ""name"": ""Revenge"",
                                ""description"": ""Prominently features a character who aims to exact punishment in a resentful or vindictive manner."",
                                ""category"": ""Theme-Drama""
                                }
                            },
                            {
                                ""count"": 26,
                                ""minutesWatched"": 8906,
                                ""tag"": {
                                ""id"": 84,
                                ""name"": ""School Club"",
                                ""description"": ""Partly or completely set in a school club scene."",
                                ""category"": ""Setting-Scene""
                                }
                            },
                            {
                                ""count"": 23,
                                ""minutesWatched"": 9098,
                                ""tag"": {
                                ""id"": 253,
                                ""name"": ""Gods"",
                                ""description"": ""Prominently features a character of divine or religious nature."",
                                ""category"": ""Cast-Traits""
                                }
                            }
                            ]
                        }
                        }
                    }
                }
            }
            ";

            string userJsonResponseNeat = userJsonResponse.Replace("\r\n", "").Replace(" ", "");

            // Act
            TopLevel userResponse = JsonConvert.DeserializeObject<TopLevel>(userJsonResponseNeat);

            // Assert, only on types with relevant equality.
            int expectedId = 137485;
            int actualId = userResponse.Data.User.Id;

            Assert.AreEqual<int>(expectedId, actualId);
            // Add breakpoint to assert by eyes.
        }
    }
}
