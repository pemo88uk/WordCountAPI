Word Count API
==============

An ASP.NET Core Web API that performs word frequency analysis on uploaded .txt files.

This solution emphasizes maintainability, testability, and extensibility, and is deployed using Docker on Render.

------------------------------------------------------------
Features
------------------------------------------------------------

- Upload a .txt file via API or web UI
- Case-insensitive word counting with punctuation ignored
- Results returned as JSON, sorted by frequency
- Download word counts as a .CSV file from the frontend
- Separation of concerns via Services, Interfaces, and Models
- Fully unit tested with xUnit
- Dockerized and publicly hosted on Render

------------------------------------------------------------
Live Demo
------------------------------------------------------------

Frontend UI: https://wordcountapi.onrender.com
GitHub Repo: https://github.com/pemo88uk/WordCountAPI

------------------------------------------------------------
Project Structure
------------------------------------------------------------

WordCountAPI/
├── wordCountAPI/              -> Main ASP.NET Core API
│   ├── Controllers/
│   ├── Interfaces/
│   ├── Models/
│   ├── Services/
│   ├── wwwroot/
│   │   └── upload.html
│   ├── Program.cs
│   └── wordCountAPI.csproj
│
├── wordCountAPI.Tests/        -> Unit test project (xUnit)
│   └── WordCounterTests.cs
│
├── Dockerfile
├── WordCountAPI.sln
└── README.txt

------------------------------------------------------------
How to Run Locally
------------------------------------------------------------

Prerequisites:
- .NET 7 SDK
- (Optional) Visual Studio 2022 or newer
- Docker (for container-based option)

Important:
If running locally, comment out or remove the following line in Program.cs:

    app.Urls.Add("http://*:80");

This line is used for Docker or hosting environments and can cause conflicts when running locally.

Option 1: Run with .NET CLI

1. Open a terminal or command prompt.
2. Navigate to the project folder where the wordCountAPI.csproj file is located:

    cd path\to\your\wordCountAPI\wordCountAPI

3. Run the application:

    dotnet run

Then open in browser:

- https://localhost:7242/upload.html

Option 2: Run with Docker

1. Open a terminal or command prompt.

2. Navigate to the project root folder (the one containing foler 'wordCountAPI' and 'README.txt'):

    cd path\to\your\wordCountAPI

3. Build and run the Docker container using the following commands:

    docker build -t wordcount-api -f wordCountAPI\Dockerfile .
    docker run -d -p 8080:80 wordcount-api

4. Then open in browser:

- http://localhost:8080/upload.html

------------------------------------------------------------
API Endpoint
------------------------------------------------------------

POST /api/wordcount

Accepts a .txt file via multipart/form-data  
Returns a list of word-count pairs, sorted by descending count

Example response:

[
  { "word": "lorem", "count": 12 },
  { "word": "ipsum", "count": 9 }
]

------------------------------------------------------------
Frontend Usage
------------------------------------------------------------

1. Go to /upload.html
2. Upload a .txt file
3. View word counts in table format
4. Click "Download as CSV" to export the result

------------------------------------------------------------
Testing
------------------------------------------------------------

The WordCounter service is fully unit tested using xUnit.

Test cases include:
- Case-insensitive word counting
- Punctuation handling
- Empty input
- Multiple variations using [Theory] and [InlineData]

To run tests:

    dotnet test

------------------------------------------------------------
Extensibility
------------------------------------------------------------

This project is built to be extensible. Future enhancements could include:

- Stop word filtering
- File history tracking
- JSON or XML export formats
- User authentication
- Database persistence
- Logging and performance metrics

------------------------------------------------------------
Deployment
------------------------------------------------------------

This project is containerized with Docker and deployable on platforms like Render.com.

If deployed, access the live version here:

    https://wordcountapi.onrender.com

------------------------------------------------------------
Author

Lukas Morkunas
GitHub: https://github.com/pemo88uk
Email: lukasmork3@gmail.com

------------------------------------------------------------
Summary

This solution meets all stated requirements:

- Maintainable: service-based architecture
- Testable: fully covered with unit tests
- Extensible: CSV export
- Publicly accessible via Render
- Dockerized for cloud deployment