# Dotent 7 ASP MVC app with identity

## Getting started
dotnet ef database update
dotnet user-secrets init
// Get app details from azure app registration in portal named netcore7app
dotnet user-secrets set "Authentication:Microsoft:ClientId" "<client-id>"
dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<client-secret>"

dotnet run


## Details

Uses aspnet core identity scaffolding see https://go.microsoft.com/fwlink/?linkid=2116645
EF/Localdb migrations
