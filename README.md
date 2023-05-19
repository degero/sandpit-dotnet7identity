# ASP Net Core Identity with Azure

## About
There are two projects using Microsoft.Identity with Azure AD App registrations. 
Microsoft.Identity.Web (MSAL wrapper) is the library recommneded by Microsoft however there are many options with other benefits/control

- IdentityEFDatabaseMultiTenant - Full ASP.NET Core Identity (including UI for account management) setup with user/session entity framework localdb and authenticating first with MicrosoftAccount + email account verification

- AzureTenantAuthMethods - Aspnet razore pages with four options of auth registrations (Identity.Web, OIDC, MicrosoftAccount and AzureAD*depreciated to identity web.)

## Reading
ASP.net core 7 authentication - https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-7.0

Setup Microsoft.Identity project for Azure auth https://github.com/AzureAD/microsoft-identity-web/wiki/web-apps#migrating-from-previous-versions--adding-authentication