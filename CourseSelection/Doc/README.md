## Database settings
Use EFCore CLI :
### Scaffold
```bash
dotnet ef dbcontext scaffold "Server=.;Database=CourseSelectionDB;Trusted_Connection=True;TrustServerCertificate=True;"Microsoft.EntityFrameworkCore.SqlServer --context CourseSelectionContext --context-dir Data --output-dir Data\Models --force
```

### Migrations
```bash
dotnet ef migrations add init --output-dir Data\Migrations --context CourseSelectionContext

dotnet ef database update
```
