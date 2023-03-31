# Dotent 7 ASP MVC app with identity

## Dependencies

.Net 7 SDK
Azure CLI (you can use az powershell if you really must 😂)
Azure account


## Getting started
dotnet ef database update

(Optional to use microsoft login provider)
dotnet user-secrets init
az login (if not alreayd done)
az ad app create --sign-in-audience AzureADandPersonalMicrosoftAccount --display-name netcore7app --web-redirect-uris https://localhost:7175/signin-microsoft
get the appId from the json response of above and put as client-id below
az ad app credential reset --id <app-id> --append 
take the result secret and set below as client-secret
dotnet user-secrets set "Authentication:Microsoft:ClientId" "<client-id>"
dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<client-secret>"

dotnet run
open https url

## Referencce

Uses aspnet core identity scaffolding see https://go.microsoft.com/fwlink/?linkid=2116645
EF/Localdb migrations
Microsoft identity provider extension
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-7.0
