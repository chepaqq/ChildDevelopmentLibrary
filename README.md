# ChildrenDevelopmentLibrary
ChildrenDevelopmentLibrary is a RESTful Web API  for managing educational programs for child development. 
# Technology
- ASP.NET Core 6.0
- EntityFramework
- SQL Server 2022
- Docker

#Building 
```
dotnet build
```
#Using
- Run WebApi
```
dotnet run --project ChildDevelopmentLibrary
```
- Run WebApi via docker
```
# Firstly build container
docker build -t webapi .
# Run docker-composer
docker-compose up
```