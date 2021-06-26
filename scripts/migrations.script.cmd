@echo off &
set /p first="Type first migration name: " &
set /p second="Type second migration name: " &
@echo on &
dotnet ef migrations script "%first%" "%second%" --framework net5.0 --project ..\Infrastructure\ --context EbookLibraryContext --configuration Release --verbose &
pause