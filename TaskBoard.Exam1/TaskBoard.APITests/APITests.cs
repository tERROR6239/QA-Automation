using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace TaskBoard.APITests
{
    public class APITests
    {

        private const string url = "https://taskboard-1.m33rschaum.repl.co/api";
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient();
        }


       
        [Test]
        public void Test_ListTheTasks_CheckFirstProject()
        {
            //Arrange
            this.request = new RestRequest(url + "/tasks");

            //Act
            var response = this.client.Execute(request, Method.Get);
            var tasks = JsonSerializer.Deserialize<List<Taskss>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(tasks[0].title, Is.EqualTo("Project skeleton"));
            
        }

        [Test]
        public void Test_FindTasks_CheckFirstResult()
        {
            //Arrange
            this.request = new RestRequest(url + "/tasks/search/{keyword}");
            request.AddUrlSegment("keyword", "home");

            //Act
            var response = this.client.Execute(request, Method.Get);
            var tasks = JsonSerializer.Deserialize<List<Taskss>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(tasks[0].title, Is.EqualTo("Home page"));
        }

        [Test]
        public void Test_FindTasks_EptyResults()
        {
            //Arrange
            this.request = new RestRequest(url + "/tasks/search/{keyword}");
            request.AddUrlSegment("keyword", "missing21314453");

            //Act
            var response = this.client.Execute(request, Method.Get);
            var tasks = JsonSerializer.Deserialize<List<Taskss>>(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(tasks.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            //Arrange
            this.request = new RestRequest(url + "/tasks ");
            var body = new
            {
                title = "",
                description = "alabala",
                board = "open"
            };
            request.AddJsonBody(body);

            //Act
            var response = this.client.Execute(request, Method.Post);


            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Title cannot be empty!\"}"));

        }

        [Test]
        public void Test_CreateTask_ValidData()
        {
            //Arrange
            this.request = new RestRequest(url + "/tasks");
            var body = new
            {
                title = "Task6239",
                description = "alabala",
                board = "open"
            };
            request.AddJsonBody(body);

            //Act Post
            var response = this.client.Execute(request, Method.Post);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            //Act Get
            var allContacts = this.client.Execute(request, Method.Get);
            var tasks = JsonSerializer.Deserialize<List<Taskss>>(allContacts.Content);
            //var lastTask = contacts[contacts.Count - 1];
            var lastTask = tasks.Last();

            //Assert
            Assert.That(lastTask.title, Is.EqualTo(body.title));
            Assert.That(lastTask.description, Is.EqualTo(body.description));

        }



    }
}