# CodingBasics
 
## AdventureWorks2019 API

## Introduction
This repository contains the API for the AdventureWorks2019 database, built with EntityFramework. It includes Swagger for API documentation.

## Prerequisites
- .NET 8

## Installation

1. **Install .NET 8**: Ensure you have .NET 8 installed on your system. You can download it from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Clone the Repository**: Clone this repository to your local machine using your preferred method.

3. **Navigate to the Project Directory**: After cloning, navigate to the project directory using your command line tool.

4. **Build the Project**:
    ```
    dotnet build
    ```

5. **Install Necessary Libraries**: If you don't have the required libraries, install them using the following commands:
    ```
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```

6. **Generate Database Context and Models**: Use the following command to scaffold the database context and models:
    ```
    dotnet ef dbcontext scaffold "Data Source=localhost;DataBase=AdventureWorks2019;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models
    ```

## Running the Application

1. **Start the Application**: Run the application using:
    ```
    dotnet run
    ```

2. **Application Configuration**: Configuration settings, including the port to run the application on, can be found and modified in the `CodingBasics.http` file.

3. **Accessing API Documentation**: The API documentation is available through Swagger at `http://localhost:5000/swagger` (assuming the default port 5000 is used).
4. To view the API views, you should navigate to the basic-client-app folder, and before testing the views, you must have the API running with the aforementioned instructions.

## Contribution
Contributions to this project are welcome. Please ensure you follow the coding standards and guidelines of the project.

## License
- [LICENSE](LICENSE)

## Contact
- **Email:** [aezequiel56@gmail.com]
- **LinkedIn:** [https://www.linkedin.com/in/josu%C3%A9-avalos-1504a3150/]
