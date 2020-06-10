@echo off

dotnet nuget push src/Markdown.Xaml/MarkdownFlowDocument.1.2.0.nupkg --api-key %API_KEY% --source https://api.nuget.org/v3/index.json
if errorlevel 1 pause
