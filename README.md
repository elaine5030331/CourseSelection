## About this excersice
- Language : C#
- Version : .Net 8
- Framework : Asp .Net Core WebAPI
- DB : MSSQL
- Unit Test : NUnit

## Database settings
> Please click the link below for the DB design, or you can use the SQL commands in MSSQL, which include the data structure and the data.
- DB design : https://dbdiagram.io/d/670de75397a66db9a3fbe50e
- SQL command : https://gist.github.com/elaine5030331/4674a482b83e115e0ef955fa7b5684ea

### settings 
Use EFCore CLI :
#### Scaffold
```bash
dotnet ef dbcontext scaffold "Server=.;Database=CourseSelectionDB;Trusted_Connection=True;TrustServerCertificate=True;"Microsoft.EntityFrameworkCore.SqlServer --context CourseSelectionContext --context-dir Data --output-dir Data\Models --force
```

#### Migrations
```bash
dotnet ef migrations add init --output-dir Data\Migrations --context CourseSelectionContext

dotnet ef database update
```

