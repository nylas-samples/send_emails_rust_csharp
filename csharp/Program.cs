// Import packages
using RestSharp;
using System;

// Load .env file
DotNetEnv.Env.Load();
DotNetEnv.Env.TraversePath().Load();


// Ask via the user via console
Console.WriteLine("Enter subject:");
string _subject = System.Console.ReadLine();
Console.WriteLine("Enter name:");
string _name = System.Console.ReadLine();
Console.WriteLine("Enter email:");
string _email = System.Console.ReadLine();
Console.WriteLine("Enter body:");
string _body = System.Console.ReadLine();
// Create a new Rest Client and call the Nylas API endpoint
var url = "https://api.us.nylas.com/v3/grants/" + Environment.GetEnvironmentVariable("GRANT_ID") + "/messages/send";
var client = new RestSharp.RestClient(url);
// Wait until the connection is done 
client.Timeout = -1;
// We want a POST method
var request = new RestSharp.RestRequest(Method.POST);
// Adding header and authorization
request.AddHeader("Content-Type", "application/json");
request.AddHeader("Authorization", "Bearer " + Environment.GetEnvironmentVariable("API_KEY_V3"));

// Formatting the body of our request
var body = @"{"
    + "\n"
    + $@"    ""body"" : ""{_body}"","
    + "\n"
    + $@"    ""subject"": ""{_subject}"","
    + "\n"
    + $@"    ""to"": ["
    + "\n"
    + @"        {"
    + "\n"
    + $@"            ""name"": ""{_name}"","
    + "\n"
    + $@"            ""email"": ""{_email}"""
    + "\n"
    + @"        }"
    + "\n"
    + @"    ]"
    + "\n"
    + @"}";

// Adding the body as a parameter
request.AddParameter("application/json", body, ParameterType.RequestBody);
// We send the request
IRestResponse response = client.Execute(request);
// Print the response
Console.WriteLine(response.Content);
// Wait for user input before closing the terminal
Console.Read();
