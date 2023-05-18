
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

public static class StartupOIDC
{
  public static void ConfigureServices(IServiceCollection services, ConfigurationManager Configuration)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(options => Configuration.Bind("AzureAd", options)); // see appsettings.json - note this uses implicit flow requiring id tokens enabled and signin-oidc set on the az ad app registration
  }
}