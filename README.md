# EventSchedulingSystem
Cloning the Repository
To clone this repository, run the following command:
----git clone https://github.com/ahmedsenosy248/Event-Scheduling-System.git


Navigate to the project directory:
----cd EventSchedulingSystem

Setting Up
Prerequisites
Ensure you have the following installed:

==Docker
==Docker Compose
==Git

Build and start the Docker containers using Docker Compose:
----docker-compose up -d
This command will:
Build the Docker images defined in docker-compose.yml.
Start the containers for the application and the PostgreSQL database.

Verify that the containers are running:
----docker ps
You should see the application and database containers listed.

Accessing APIs
Once the containers are running, you can access the APIs:

HTTP API: http://localhost:8081
HTTPS API: https://localhost:8082
Use tools like Postman or cURL to interact with the API endpoints.

Example Request
To register a new user, send a POST request to http://localhost:8081/api/Auth/register with the following JSON body:
{
  "username": "ahmedsenosy246",
  "email": "ahmedsenosy246@gmail.com",
  "phoneNumber": "01010101010",
  "password": "Ahmed@12345"
}

Log In and Generate a Token
After registering, log in to generate a JWT token. You can use the login endpoint to get the token.

Access Protected API Endpoints:

Once you have the token, you can use it to access protected API endpoints. For example, to create a new event, send a POST request to https://localhost:8082/api/Event with the following cURL command in Postman:

curl -X 'POST' \
  'https://localhost:8082/api/Event' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "3fa85f64-5671-4562-b3fc-2c963f66afa6",
  "title": "Wedding",
  "description": "party",
  "date": "2024-08-02T01:48:52.186Z",
  "time": "00:00:20",
  "location": "string"
}'

Pushing Docker Images to Docker Hub
Prerequisites
Docker Hub account
Log in to Docker Hub
----docker login


Enter your Docker Hub username and password when prompted.

Tag and Push the Docker Image

Tag the Docker image:
----docker tag eventschedulingsystem:dev ahmedsenosy248/eventschedulingsystem:dev
----docker tag postgres:16 ahmedsenosy248/eventschedulingsystem:dev

Push the Docker image:
----docker push ahmedsenosy248/eventschedulingsystem:dev



Link to the public GitHub repository: 
  ==>  git clone https://github.com/ahmedsenosy248/Event-Scheduling-System.git

  Access to the Docker Hub repository containing Docker images 
  ==>  docker pull ahmedsenosy248/eventschedulingsystem:dev








