// Import packages
using RestSharp;

// Load .env file
DotNetEnv.Env.Load();
DotNetEnv.Env.TraversePath().Load();

// Ask via the user via console
Console.WriteLine("Enter subject:");
string _subject = Console.ReadLine();
Console.WriteLine("Enter name:");
string _name = Console.ReadLine();
Console.WriteLine("Enter email:");
string _email = Console.ReadLine();
Console.WriteLine("Enter body:");
string _body = Console.ReadLine();
// Create a new Rest Client and call the Nylas API endpoint
var url = "https://api.us.nylas.com/v3/grants/" + Environment.GetEnvironmentVariable("GRANT_ID") + "/messages/send";
var client = new RestClient(url);
// We want a POST method
var request = new RestRequest();
// Adding header and authorization
request.AddHeader("Accept", "application/json");
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
request.AddStringBody(body, ContentType.Json);
// We send the request
RestResponse response = client.ExecutePost(request);
// Print the response
Console.WriteLine(response.Content);
// Wait for user input before closing the terminal
Console.Read();
