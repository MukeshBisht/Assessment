# Software Engineer Home Assignment

## Library used
<a href="https://github.com/commandlineparser/commandline/wiki" >CommandLineParser</a>
</br>
<a href="https://github.com/moq/moq4" >Moq</a>

## How to use

- Install <a href="https://dotnet.microsoft.com/download/dotnet/5.0" >.NET 5</a> SDK
- Clone Repository
```
git clone https://github.com/MukeshBisht/Assessment.git
```
- Change working directory to project
```
cd .\Assessment\coding\FeedImport
```
- Restore
```
dotnet restore
```
- Test [![.NET](https://github.com/MukeshBisht/Assessment/actions/workflows/build-test.yml/badge.svg)](https://github.com/MukeshBisht/Assessment/actions/workflows/build-test.yml)
```
dotnet test
```


- Run
```
cd ./Import
dotnet run 
dotnet run capterra .\feed-products\capterra.yaml
```

## Where to find the code
- Directory <b>Assessment\coding\FeedImport</b> has dotnet project solution file 
- <a href="https://github.com/MukeshBisht/Assessment/tree/main/database"> SQL Test Solution </a>

## Scope of work
- Separate projects for feed modules (CapterraFeed, SoftwareAdvice).
- Separate infrastucture project for database.
- Functional tests for import command line project.
