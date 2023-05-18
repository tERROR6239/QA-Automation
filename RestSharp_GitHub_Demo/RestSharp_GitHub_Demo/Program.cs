using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

var client = new RestClient("http://api.github.com");

///var request = new RestRequest("/repos/tERROR6239/postman/issues/1");
///var request = new RestRequest("/repos/{user}/{repos}/issues/{id}");
//request.AddUrlSegment("user", "tERROR6239");
//request.AddUrlSegment("repos", "postman");
//request.AddUrlSegment("id", "1");

var request = new RestRequest("/users/{user}/repos");
request.AddUrlSegment("user", "tERROR6239");

var response = await client.ExecuteAsync(request, Method.Get);

//Превтъща стринга в обект и обекта в стринг.
var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

foreach (var repo in repos)
{
    Console.WriteLine("Repo Full Name: " + repo.full_name);
    Console.WriteLine("Repo ID: " + repo.id);
    Console.WriteLine("*****************************");
}
