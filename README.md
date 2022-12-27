# ChildrenDevelopmentLibrary
ChildrenDevelopmentLibrary is a RESTful Web API  for managing educational programs for child development. 
# Technology
- ASP.NET Core 6.0
- EntityFramework
- SQL Server 2022
- Docker

# Building 
```
dotnet build
```
# Using
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
# Examples
- GET /api/Child/{status}
```http://localhost:5000/api/Child/1```
- POST /api/EducationalProgram/SubscribeToProgram/child/{childId}/program/{programId}
```http://localhost:5000/api/EducationalProgram/SubscribeToProgram/child/1/program/1```
- PUT ​/api​/EducationalProgram​/StartStudying​/child​/{childId}​/program​/{programId}
```http://localhost:5000/api/EducationalProgram/StartStudying/child/1/program/1```
- POST ​/api​/EducationalProgram​/CompleteStudying​/child​/{childId}​/program​/{programId}
```http://localhost:5000/api/EducationalProgram/CompleteStudying/child/1/program/1```