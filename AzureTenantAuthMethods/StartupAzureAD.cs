

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.Cookies;

public static class StartupAzureAD
{
  public static void ConfigureServices(IServiceCollection services, ConfigurationManager Configuration)
  {
    services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
    .AddCookie() // Do not use for identityweb
   .AddAzureAD(options => Configuration.Bind("AzureAd", options)); // see appsettings.json - note requires signin-microsoft set on the az ad app registration
  }
}