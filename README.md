# Capstone_library 

Project: capstone_library.WebAPI
Overview
This project is an ASP.NET Core web API for a library management system. It provides a RESTful interface for managing book data and is designed to be a backend service for client-side applications.

How to Run the Project
Open Solution: Open the capstone_library.sln file in Visual Studio.

Set Startup Project: Right-click the capstone_library.WebAPI project in Solution Explorer and select Set as Startup Project.

Execute: Run the project by pressing the F5 key. The application will launch and open a web browser with the API's Swagger documentation.

How to Run Tests
Open Test Explorer: Navigate to Test > Test Explorer in the Visual Studio menu.

Build Solution: Ensure all project code is compiled by selecting Build > Build Solution or using the Ctrl + Shift + B keyboard shortcut.

Run Tests: In the Test Explorer window, click the Run All button to execute all unit tests. Test results will be displayed in the same window.

Example Usage
The following examples demonstrate how to interact with the API endpoints using curl commands. Replace [PORT] with the port number assigned to your local instance.

Retrieve All Books
Method: GET

URL: https://localhost:[PORT]/books

Command:

curl -X GET "https://localhost:[PORT]/books" -H "accept: text/plain"

Example Response:

[
    {
        "id": 1,
        "title": "The Giver",
        "author": "Lois Lowry",
        "isAvailable": true
    },
    {
        "id": 2,
        "title": "Dune",
        "author": "Frank Herbert",
        "isAvailable": false
    }
]

Retrieve a Specific Book by ID
Method: GET

URL: https://localhost:[PORT]/books/{id}

Command:

curl -X GET "https://localhost:[PORT]/books/1" -H "accept: text/plain"

Create a New Book
Method: POST

URL: https://localhost:[PORT]/books

Body:

{
    "title": "The Hitchhiker's Guide to the Galaxy",
    "author": "Douglas Adams",
    "isAvailable": true
}

Command:

curl -X POST "https://localhost:[PORT]/books" \
-H "accept: text/plain" \
-H "Content-Type: application/json" \
-d "{\"title\":\"The Hitchhiker's Guide to the Galaxy\",\"author\":\"Douglas Adams\",\"isAvailable\":true}"
