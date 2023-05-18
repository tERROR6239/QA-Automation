using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace ShortURL_Tests
{
    public class ApiTests
    {
        private const string base_url = "http://localhost:8080/api";
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient();
        }


        [Test]
        public void ListURL_Test()
        {
            //Arrange
            this.request = new RestRequest(base_url + "/urls");

            //Act
            var response = this.client.Execute(request, Method.Get);
            var urlss = JsonSerializer.Deserialize<List<Urlss>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(urlss.Count, Is.GreaterThan(0));

        }

        [Test]
        public void Search_ShortCodeValid_Test()
        {
            // Arrange
            var request = new RestRequest(base_url + "/urls/seldev");

            // Act
            var response = client.Execute(request, Method.Get);
            var short_url = JsonSerializer.Deserialize<Urlss>(response.Content);
            
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(short_url);
            Assert.That(short_url.shortCode, Is.EqualTo("seldev"));
            Assert.That(short_url.urll, Is.EqualTo("https://selenium.dev"));

        }

        [Test]
        public void Search_ShortCodeInvalid_Test()
        {
            //Arrange
            this.request = new RestRequest(base_url + "/urls/invalid");
            
            //Act
            var response = this.client.Execute(request, Method.Get);
            var urlss = JsonSerializer.Deserialize<Urlss>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Short code not found: invalid\"}"));

        }

        [Test]
        public void Create_NewShortUrl_Test()
        {
            //Arrange
            this.request = new RestRequest(base_url + "/urls");
            var body = new
            {
                url = "https://cnn.com",
                shortCode = "cnn",
            };
            request.AddJsonBody(body);

            //Act Post
            var response = this.client.Execute(request, Method.Post);

            //Assert Post
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            //Act Get
            var allUrls = this.client.Execute(request, Method.Get);
            var urlss = JsonSerializer.Deserialize<List<Urlss>>(allUrls.Content);
            //var lastUrl = urlss[urlss.Count - 1];
            var lastUrl = urlss.Last();

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(lastUrl.urll, Is.EqualTo(body.url));
            Assert.That(lastUrl.shortCode, Is.EqualTo(body.shortCode));

        }

        [Test]
        public void Delete_NewShortUrl_Test()
        {
            //Arrange
            this.request = new RestRequest(base_url + "/urls/cnn");
            
            //Act
            var response = this.client.Execute(request, Method.Delete);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            //Arrange
            this.request = new RestRequest(base_url + "/urls/cnn");
            //Act
            var newresponse = this.client.Execute(request, Method.Get);
            
            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo("{\"msg\":\"URL deleted: cnn\"}"));

        }

    }
}