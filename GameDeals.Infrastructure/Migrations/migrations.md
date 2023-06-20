# How to new add migrations
cd .\GameDeals.Api\
dotnet ef migrations add Initial --verbose --context ApplicationDbContext --project ..\GameDeals.Infrastructure\ --output-dir Migrations
dotnet ef database update