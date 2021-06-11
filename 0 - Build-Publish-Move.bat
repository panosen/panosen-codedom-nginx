@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Nginx\bin\Release\Panosen.CodeDom.Nginx.*.nupkg D:\LocalSavoryNuget\

pause