using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text.Json;

var client = new RestClient("http://api.github.com");
client.Authenticator = new HttpBasicAuthenticator("tERROR6239", "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");

//var request = new RestRequest("/repos/tERROR6239/postman/issues/1");
string url = "/repos/{user}/{repos}/issues";
var request = new RestRequest(url);
request.AddUrlSegment("user", "tERROR6239");
request.AddUrlSegment("repos", "postman");

request.AddBody(new { title = "New issue from RestSharp" });

var response = await client.ExecuteAsync(request, Method.Post);

Console.WriteLine("Status Code: " + response.StatusCode);
Console.WriteLine("Content: " + response.Content);