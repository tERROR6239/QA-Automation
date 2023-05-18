using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace Test.lab11
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_GitHubAPIRequests()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/repos/tERROR6239/Postman/issues", Method.Get);
            var response = await client.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}