# TodoistDocker
Dockerized version of Todoist

# Functionality
 - This app is a very basic todo app which uses the following stack: 
   - ASP.NET 5 for Backend
   - MYSQL for Database
   - Swagger UI for frontend
  - The core idea here is to just store a list of todo tasks and display them when needed, as of now I have implmeneted only 2 APIS one for listing todos,
    second one for adding a todo item, as most focus here is on the deployment part. Even if the app grows complex in nature the deployment part stays
    pretty much constant once decided.
# Docker 
  - The idea here is to isolate database deployment from the actual app, so we have used a seperate docker container running mysql container and a sepearate
    container running Web application, this way the load is less on either of the containers and is also inline with good deployment practices.
  - Inorder to orchestrate container creation / removal a convinent docker compose script is provided, the script is very basic and accomplishes the following
     - Creates a db by pulling from mysql:5.7 docker container registry and sets some environment variables like username, password, database name and initial 
       database bootstrapping scripts, this service is named as "db"  and can be accessed by any other container in the same network using the same name
     - Creates another container by building the web app and the build instructions are specified in the Dockerfile (this part is done from scratch as it was asked so)
        - The Dockerfile starts based on Ubuntu:20.04
        - It installs wget for obtaining microsoft's debian package to configure ubuntu's repository settings
        - Once the settings are configured, it installs ASP.NET 5 sdk as per the [docs](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)
        - Once the SDK is installed, we set the working directory to /app 
        - copy the source code to the container
        - build the source code using dotnet restore
        - expose the neccessary ports for container to work correctly
        - set an entry point by launching kerestel web server and accept all requests
      - However it's important that the database becomes available before this service, hence there is an explict dependency add in compose file on datbase to be provisoned 
        before running any of the above steps
   - Since both containers are running on the default docker compose network, the web application can reference the database by it's service name "db" and this is 
     evident from [connection strings](https://github.com/sasi-1995/TodoistDocker/blob/78a7ffe83c29b47e4176a8352c55b99b1c06bfe8/Todoist/appsettings.json#L3) 
   - Once the webserver starts, it ensures all the code migrations are applied and accepts the http requests.

# How to get the magic working ?
  - Simple just run docker-compose up
  - Once you see the application started navigate to http://localhost:5000
  
