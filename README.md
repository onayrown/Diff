# DiffedData
This repo contains a sample AspNet Core WebApi application to Get the data difference between two endpoints. 

<h3>Definition:</h3>
Exists an endpoint Left and an endpoint Right where both can receive Json Base64 encoded data. And exist a third endpoint called Compare the compares those data received by Left and Right endpoints.

<h3>Some assumptions were made during the implementation:</h3>

If the endpoints Left and Right have the same data (in Lenght and content) the return is the content and a message informing that they are equals.

If the endpoints Left and Right have a different Lenght. The return is a message, informing that they are different.

If the endpoint Left and Right have the same Lenght but different content. The return is a message, informing that they have the same length but the content is different. And shows where are each difference on Left data content and Right data content.

The Repository of this application is just a static class, that holds the data in memory during the execution. A real database can be easily replaced with little effort. Since a repository pattern was used and all business logic has been separated into another layer.

This application was covered with unit tests using xUnit. (Nothing too much sophisticate was used and no mock frameworks were used for these tests. But they were efficient to cover the most important aspects of the code).

The API documentation was implemented using swagger and can be accessed at APIAddress/swagger

<h3>Some missing points (Future implementations):</h3>

Integrations tests to cover the API controller using real data (It means a real database).  Since the database is a static class, a good approach will be using the Postman application and your CLI tool called Newman.

Use a mock framework like MOQ to mock the data and prevent any data modification break the tests.

Add a docker file to the application. preferential when the application had a real database to build an independent container and make it easy to be scalable.
