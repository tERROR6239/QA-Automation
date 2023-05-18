using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestGitHubApi
{
    public class Github_Tests
    {
        private RestClient client;
        private RestRequest request;


        [SetUp]
        public void Setup()
        {
            this.client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator("tERROR6239", "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");

        }

        [Test]
        public async Task Test_Get_IssuesAsync()
        {
            this.request = new RestRequest("/repos/tERROR6239/postman/issues");
            var response = await client.ExecuteAsync(request); //, Metod.Get

            var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.Greater(issue.id, 0);
                Assert.Greater(issue.number, 0);
                Assert.IsNotEmpty(issue.title);
                Assert.IsNotNull(issue.html_url);
                Assert.IsNotNull(issue.id, "Issue id must not be null");
            }

            Assert.IsNotNull(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        private async Task<Issue> CreateIssue(string title, string body)
        {
            var request = new RestRequest("/repos/tERROR6239/postman/issues");
            request.AddBody(new { body, title });
            var response = await client.ExecuteAsync(request, Method.Post);
            var issue = JsonSerializer.Deserialize<Issue>(response.Content);
            return issue;
        }

        [Test]
        public async Task Test_Create_GitHubIssueAsync()
        {
            string title = "New issue from RestSarp";
            string body = "Some body here";
            var issue = await CreateIssue(title, body);
            Assert.Greater(issue.id, 0);
            Assert.Greater(issue.number, 0);
            Assert.IsNotEmpty(issue.title);
        }

        [Test]
        public void Test_Get_Issue()
        {
            //Arrange
            this.request = new RestRequest("/repos/tERROR6239/postman/issues/1");

            //Act
            var response = this.client.Execute(request, Method.Get);
            var issue = JsonSerializer.Deserialize<Issue>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(issue.id, Is.EqualTo(1234843084));
            Assert.That(issue.title, Is.EqualTo("First isssue from web ui"));
        }

        [Test]
        public void Test_Create_Issue()
        {
            //Arrange
            this.request = new RestRequest("/repos/tERROR6239/postman/issues");
            var body = new
            {
                title = "New issue from RestSarp v2",
                body = "ome body here",

            };
            request.AddJsonBody(body);

            //Act Post
            var response = this.client.Execute(request, Method.Post);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            //Act Get
            var response2 = this.client.Execute(request, Method.Get);
            var issue = JsonSerializer.Deserialize<List<Issue>>(response2.Content);

            //Assert
            Assert.That(issue[0].title, Is.EqualTo(body.title));
            Assert.That(issue[0].body, Is.EqualTo(body.body));

        }
    }
}
