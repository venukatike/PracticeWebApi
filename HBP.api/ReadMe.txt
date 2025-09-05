# Example: using localdb
CONN="Server=(localdb)\\mssqllocaldb;Database=HBP;Trusted_Connection=True;"

Server = DESKTOP-VUVTT19\SQLEXPRESS
Database =HBP

"Default": "Server=DESKTOP-VUVTT19\\SQLEXPRESS;Database=CodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"

dotnet ef dbcontext scaffold "Server=DESKTOP-VUVTT19\SQLEXPRESS\\mssqllocaldb;
Database=HBP;Trusted_Connection=True;" 
Microsoft.EntityFrameworkCore.SqlServer
  --output-dir Models
  --context-dir Data
  --context BillingDbContext
  --schemas dbo 
  --use-database-names 
  --force

If you want to scaffold only specific tables

dotnet ef dbcontext scaffold "$CONN" Microsoft.EntityFrameworkCore.SqlServer \
  --output-dir Models \
  --context-dir Data \
  --context BillingDbContext \
  --table Patient --table Insurance --table PatientInsurance --table InsuranceVerification \
  --use-database-names --force

SQLite (if your DB is sqlite)

CONN="Data Source=healthcare.db"
dotnet ef dbcontext scaffold "$CONN" Microsoft.EntityFrameworkCore.Sqlite \
  --output-dir Models --context-dir Data --context BillingDbContext --force