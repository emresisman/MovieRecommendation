# MovieRecommendation App
Movie recommendation web api project.

## Dependencies

SDK .Net 5

## Installation

Install Docker and start SQL Server.

```sh
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Passw0rd' -e 'MSSQL_PID=Developer' -p 1433:1433 -h sql2k17 -d mcr.microsoft.com/mssql/server:2017-latest
```

Copy repository to your local.

```sh
git clone https://github.com/emresisman/MovieRecommendation.git
```

Go to project root folder and run Migration command in Package Manager Console

```sh
dotnet ef database update --project MovieRecommendation.DAL --startup-project MovieRecommendation.WebAPI
```

Run MovieRecommendation.Crawler to fill your Movies database.

```sh
dotnet run --project MovieRecommendation.Crawler/MovieRecommendation.Crawler.csproj
```

Set new SendGrid.APIKey value in appsetting.json of MovieRecommendation.WebAPI project. (Can get from https://www.themoviedb.org/)

Run MovieRecommendation.WebAPI project. 

```sh
dotnet run --project MovieRecommendation.WebAPI/MovieRecommendation.WebaPI.csproj
```