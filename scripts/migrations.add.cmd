@echo off &
set /p name="Type migration name: " &
@echo on &
dotnet ef migrations add "%name%" --framework net5.0 --project ..\Infrastructure\ --context EbookLibraryContext --configuration Release --output-dir Migrations --verbose &
pause