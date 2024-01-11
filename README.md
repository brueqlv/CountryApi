Task:
1. Create a WebApi .NET 6 application that consumes data from
https://restcountries.com/ API v3+
2. We are only interested in European Union countries, our internal data model only
needs info on the country name, area, population, tld, native name (and any
extra needed).
3. Create REST API for the following:
a. Top 10 countries with the biggest population
b. Top 10 countries with the biggest population density (people / square km)
c. By passing a specific country (eg /country/latvia) return everything you
have on that country in your model except the country name
4. Add unit tests
5. Swagger for the endpoints
Deliverables:
1. Link to a GitHub repository
2. Description of how to run your program


How to run this application:

Prerequisites:
1. Make sure you have necessary tools installed:
   a. .Net SDK
   b. An integrated development enviroment like Visual Studio
2. Clone the project:
   a. git clone <repository-url>
   b. cd <project-directory>

Running the Web Api:
1.Open terminal or command prompt in the project directory.
2.Build the project using the following command: dotnet build
3.Run the project: dotnet run
4.Once the application is running, open your web browser and navigate to 
https://localhost:7217/swagger. This will open the Swagger UI, where you can test your API endpoints.
Change localhost number to your number.

Testint the endpoints:
1.To get top 10 countries by population, use the following endpoint in Swagger or any API testing tool:
  a. https://localhost:7217/api/Country/top10/population
2. To get top 10 countries by population density, use the following endoint:
  a. https://localhost:7217/api/Country/top10/populationDensity
3. To get details about specific country, use the following endpoint:
  a. https://localhost:7217/api/Country/{country}/details
  b. https://localhost:7217/api/Country/Latvia/details

Remember to replace <repository-url> and <project-directory> with your actual Git repository URL and project directory.
The guide assumes, that your application runs on port(7217), if it is running on diferent port then adjust URLs accordingly.
