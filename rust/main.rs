// Import your dependencies
use reqwest; //HTTP Client
use std::io; //Input-Output
use serde_json::json; //Json handler
use std::env; //Read .env files

// tokio let's us use "async" on our main function
#[tokio::main]
async fn main() {

// Read the .env file
dotenv::dotenv().expect("Failed to read .env file");

// Add the ACCESS_TOKEN to the Authorization string
let mut _access_token = String::new();
_access_token = "Bearer ".to_owned() +  &env::var("V3_API_KEY").expect("Not found");

// Request the parameters
println!("Enter a subject: ");
let mut _subject = String::new();
io::stdin().read_line(&mut _subject)
			 .expect("failed to read");

println!("Enter a name: ");
let mut _name = String::new();
io::stdin().read_line(&mut _name)
              .expect("failed to read");

println!("Enter an email: ");   
let mut _email = String::new();
io::stdin().read_line(&mut _email)
              .expect("failed to read");

println!("Enter the body: ");              
let mut _body = String::new();
io::stdin().read_line(&mut _body)
              .expect("failed to read");

let trim_subject = _subject.trim();
let trim_name = _name.trim();
let trim_email = _email.trim();
let trim_body = _body.trim();

// Create the JSON structure
let _fields = json!({
	"subject": &trim_subject,
	"to": [
    {
      "email": &trim_email,
      "name": &trim_name
    }
  ],
  "body": &trim_body,
});
    
    let mut _url = String::new();
    _url = "https://api.us.nylas.com/v3/grants/".to_owned() + &env::var("GRANT_ID").expect("Not found") + "/messages/send";
    let client = reqwest::Client::new();
    let response = client
		.post(_url)
		.header("Authorization", _access_token.to_string())
		.header("Content-type", "application/json")
		.header("Accept", "application/json")
		.json(&_fields)
		.send()
        .await
        .unwrap() // Give the back the result of panic if it fails
        .text() // Convert it to plain text
        .await;
    
    println!("{:?}", response);
}
