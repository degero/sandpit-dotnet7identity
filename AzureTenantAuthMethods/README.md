# OpenIDConnect client to Single tenant AZ AD

## Dependencies

.net 7
azure cli

## Setup

Select the mode you wish to use in Program.cs authLibraryMode (note these are all based on single tenant auth)

Run az cli command (adjust the port to your local app)
az ad app create --sign-in-audience AzureADMyOrg --display-name netcore7appsingletenant --web-redirect-uris https://localhost:7175/signin-oidc https://localhost:7175/signin-microsoft

In the portal:
create a secret for the app if using MicrosoftAccount mode in Program.cs
check the ID tokens if using OIDC mode in Program.cs

Add client id / tenant / domain details to appsettings.json

If using StartupMicrosoftAccount mode
Add clientid / secret / tenant to StartupMicrosoftAccount.cs

If using OpenIDConnect specify authority in appsettings.json

## Notes

There are two main libraries, Microsoft.Identity.Web or the Microsoft.AspNetCore.Authentication.* libraries
The key choice appears to be that identity.Web will allow api calls

There are dotnet templates for creating auth apps

dotnet new -i Microsoft.Identity.Web.ProjectTemplates::1.15.2
https://github.com/AzureAD/microsoft-identity-web/wiki

## Other reading

https://github.com/AzureAD/microsoft-identity-web
https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2
https://learn.microsoft.com/en-us/azure/active-directory/develop/web-app-tutorial-01-register-application
https://learn.microsoft.com/en-us/azure/active-directory/develop/sample-v2-code#web-applications
https://learn.microsoft.com/en-us/samples/azure-samples/active-directory-aspnetcore-webapp-openidconnect-v2/enable-webapp-signin/?view=aspnetcore-7.0