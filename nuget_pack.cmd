@echo off

dotnet pack src\Markdown.Xaml\MarkdownFlowDocument.csproj --configuration Release /property:PackageVersion=1.2.0 /p:PackageOutputPath=. /p:Authors=Author
if errorlevel 1 pause
