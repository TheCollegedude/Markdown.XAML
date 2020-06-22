@echo off

dotnet pack src\Markdown.Xaml\MarkdownFlowDocument.csproj --configuration Release /property:PackageVersion=1.6.1 /p:PackageOutputPath=.
if errorlevel 1 pause
