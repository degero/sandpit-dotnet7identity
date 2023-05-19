
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;

public static class StartupMicrosoftAccount
{
  public static void ConfigureServices(IServiceCollection services, ConfigurationManager Configuration)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Do not use for identityweb mode
      options.DefaultChallengeScheme = MicrosoftAccountDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddMicrosoftAccount(microsoftOptions => // This is for single tenant, if your app was configured with 
    {
      microsoftOptions.ClientId = "<clientid>";
      microsoftOptions.ClientSecret = "<clientsecret>";
      microsoftOptions.AuthorizationEndpoint =
          $"https://login.microsoftonline.com/<tenantid>/oauth2/v2.0/authorize";
      microsoftOptions.TokenEndpoint =
          $"https://login.microsoftonline.com/<tenantid>/oauth2/v2.0/token";

    });
  }
}