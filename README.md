# CheckoutRestApi

## Steps to run the project
- CLone the whole project in your local.
- open terminal.
- enter 'cd goCompareTest' to go inside of project directory.
- enter 'dotnet build' to build the project.
- enter 'donet test' to check the unit test cases.
- enter 'dotnet run' to run the project.
- To check the API documentation open browser and enter 'http://localhost:5283/swagger/index.html'      please change the port accordingly.

## Steps to create Docker Image run it on docker.
- Install Docker.
- enter 'docker build . -t gocomparetest' it will create a docker image with name gocomparetest.
- enter 'docker run -p 8081 -e ASPNETCORE_URLS=http://+:80  gocomparetest' it will run docker image on URL:'http://localhost:8081/swagger/index.html'.
