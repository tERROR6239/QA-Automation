using RestSharp;
using System;

var client = new RestClient("https://api.github.com");

var request = new RestRequest("/repos/{user}/{repo}/issues");

request.AddUrlSegment("user", "tERROR6239");
request.AddUrlSegment("repo", "postman");

var response = await client.ExecuteAsync(request);

Console.WriteLine("Status Code" + response.StatusCode);
Console.WriteLine("Body: " + response.Content);