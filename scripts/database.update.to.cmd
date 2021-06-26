@echo off &
set /p name="Type migration name: " &
@echo on &
dotnet ef database update "%name%" --framework net5.0 --project ..\Infrastructure\ --context EbookLibraryContext --configuration Release --verbose &
pause