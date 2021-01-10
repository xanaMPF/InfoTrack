using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using System.Net.Http;
using Moq.Protected;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using Scraper.Infrastructure.Models;
using Scraper.Domain.Services.WebScraper;

namespace Scraper.Domain.UnitTest
{
    public class ScraperUnitTests
    {
        const string VALID_URL = "www.infotrack.co.uk";
        const string INVALID_URL = "www.notAWebsite.com";
        const string KEYWORDS = "land registry searches";

        SearchEngine GoogleSE;
        ScraperService service;

        [SetUp]
        public void Setup()
        {
            GoogleSE = new SearchEngine()
            {
                Name = "Google",
                BaseAddress = "http://www.google.com/search",
                Limit = "num",
                Query = "q",
                RegexTag = "<div class=\"g\"(.*?)</div>"
            };

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpMessageHandlerMock.Protected()
                                  .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                                  .ReturnsAsync(new HttpResponseMessage()
                                  {
                                      StatusCode = HttpStatusCode.OK,
                                      Content = new StringContent(TestUtils.HTML_RESPONSE),
                                  })
                                  .Verifiable();

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            service = new ScraperService(httpClient);
        }

        [Test]
        public async Task GetRankings_GoogleUK_URLInfoTrack_KeywordsLandRegistrySearch()
        {
            
            var results = await service.GetRankingsForKeyword(GoogleSE, VALID_URL, KEYWORDS);

            Assert.AreEqual(GoogleSE.Name, results.SearchEngineName);
            Assert.AreEqual(6, results.BestRank);
            var expectedRanks = new List<int>
            {
                6
            };
            CollectionAssert.AreEqual(expectedRanks, results.Ranks);
        }

        [Test]
        public async Task GetRankings_GoogleUK_URLInvalid_KeywordsLandRegistrySearch()
        {

            var results = await service.GetRankingsForKeyword(GoogleSE, INVALID_URL, KEYWORDS);

            Assert.AreEqual(GoogleSE.Name, results.SearchEngineName);
            Assert.IsNull(results.BestRank);
            Assert.IsNull(results.Ranks);
        }
    }
}