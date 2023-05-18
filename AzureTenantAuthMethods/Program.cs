using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var Configuration = builder.Configuration;

var authLibraryMode = "MicrosoftAccount";

switch (authLibraryMode)
{
  case "IdentityWeb":
    // Identity.Web setup - Requires ID tokens in your app registration
    StartupIdentityWeb.ConfigureServices(builder.Services, Configuration);
    break;
  case "AzureAD":
    StartupAzureAD.ConfigureServices(builder.Services, Configuration);
    break;
  case "OIDC":
    // OIDC Setup - Requires ID tokens in your app registration
    StartupOIDC.ConfigureServices(builder.Services, Configuration);
    break;
  case "MicrosoftAccount":
    // MicrosoftAccount setup - Requires settings added to StartupMicrosoftAccount.cs also can use with az ad app audencies: AzureADMultipleOrgs AzureADandPersonalMicrosoftAccount
    StartupMicrosoftAccount.ConfigureServices(builder.Services, Configuration);
    break;
}

builder.Services.AddAuthorization(options =>
{
  // All pages are secured by this setting 
  // options.FallbackPolicy = new AuthorizationPolicyBuilder()
  //     .RequireAuthenticatedUser()
  //     .Build();
});
// OR you can sett through the page filters
// builder.Services.AddControllersWithViews(options =>
// {
//   var policy = new AuthorizationPolicyBuilder()
//       .RequireAuthenticatedUser()
//       .Build();
//   options.Filters.Add(new AuthorizeFilter(policy));
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Needed for identity.web

app.Run();
