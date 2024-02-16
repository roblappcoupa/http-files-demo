## .HTTP Files Demo

### What are .http files?

1. http files are a text based file format that follows the semantics of the HTTP protocol
2. Define one or more HTTP requests and then send the requests using the IDE of your choice
3. Rely on IDE for a variety of features
4. Programming language and technology stack agnostic

### Features supported by most IDEs
1. Sending and receiving HTTP requests
2. Pre and post request scripts
3. Tests
4. Format conversion (e.g., convert Curl request to .http file format or import Postman collections)
5. Environments
6. Multipart HTTP requests
6. GraphQL, Websocket and gRPC

### IDE Support
1. [Visual Studio](https://learn.microsoft.com/en-us/aspnet/core/test/http-files?view=aspnetcore-8.0)
2. [Visual Studio Code (REST Client extension)](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
2. [Rider](https://www.jetbrains.com/help/rider/Http_client_in__product__code_editor.html)

### Running the app
First, start the service in Rider, Visual Studio or from the command line:
```text
dotnet run --project ./WebApi/WebApi.csproj
```
Then navigate to the `http-files` folder in an IDE. Run the requests.

### Examples
1. Basic requests
2. Tests
3. Variables
4. Pre and post request scripts
4. Environments
5. Curl to .http file
6. Automatic generation of .http files
