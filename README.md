Related to the livestream https://www.youtube.com/watch?v=7gqnMf15fAA&list=PLk-4iahO3b-xd42-RL4DJQyuEoFFYwTbC&index=7

### Gather environment variables

You'll need the following values:

```text
V3_API_KEY = ""
GRANT_ID = ""
```

Add the above values to a new `.env` file:

```bash
$ touch .env # Then add your env variables
```

### For Rust

Type this in your **Cargo.toml file**

```
[package]
name = "send_email"
version = "0.1.0"
edition = "2021"
# See more keys and their definitions at https://doc.rust-lang.org/cargo/reference/manifest.html
[dependencies]
reqwest = { version = "0.11", features = ["json"] } # reqwest with JSON parsing support
futures = "0.3" # for our async / await blocks
tokio = { version = "1.12.0", features = ["full"] } # for our async runtime
serde_json = "1.0" #to handle json
dotenv = "0.15.0" # for reading .env file
[profile.release]
opt-level = 'z'     # Optimize for size.
lto = true          # Enable Link Time Optimization
codegen-units = 1   # Reduce the number of codegen units to increase optimizations.
panic = 'abort'     # Abort on panic
strip = true        # Strip symbols from binary*
```

Compile with:

```
$ cargo build --release
```

Execute with:

```
$ ./send_email
```

### For C#

On **send_email.csproj** we need to include the following code:

```
<Project Sdk="Microsoft.NET.Sdk">
 <PropertyGroup>
   <OutputType>Exe</OutputType>
   <TargetFramework>net6.0</TargetFramework>
   <ImplicitUsings>enable</ImplicitUsings>
   <Nullable>enable</Nullable>
 </PropertyGroup>
 <ItemGroup>
   <PackageReference Include="DotNetEnv" Version="2.3.0" />
   <PackageReference Include="RestSharp" Version="106.15" />
 </ItemGroup>
</Project>
```

Build project and run with:

```
$ cd bin/Debug/net6.0
```
