using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Zipopotamus.APITests
{
    public class ZipopotamusApiTests
    {
        private const string url = "https://api.zippopotam.us";
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(url);
        }

        [TestCase("BG", "1000", "Sofija", "Sofija")]
        [TestCase("BG", "8000", "Burgas", "Burgas")]
        [TestCase("BG", "5300", "Gabrovo", "Purtevci")]
        [TestCase("BG", "5000", "Veliko Turnovo", "Veliko Turnovo")]
        [TestCase("CA", "M5S", "Ontario", "Toronto")]
        [TestCase("US", "10115", "New York", "New York City")]
        [TestCase("GB", "WC2N", "England", "London")]
        [TestCase("DE", "10115", "Berlin", "Berlin")]
        public void TestZipopotamus(string countryCode, string zipCode, string expectedState, string expectedTown) 
        {
            var request = new RestRequest(countryCode + "/" + zipCode);
            
            var response = client.Execute(request, Method.Get);
            var location = new SystemTextJsonSerializer().Deserialize<Location>(response);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));     
            Assert.That(zipCode, Is.EqualTo(location.postCode));
            StringAssert.Contains(expectedState, location.Places[0].State);
            StringAssert.Contains(expectedTown, location.Places[0].PlaceName);

        }
    }
}