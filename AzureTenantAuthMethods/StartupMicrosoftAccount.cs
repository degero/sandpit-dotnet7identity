
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
      microsoftOptions.ClientId = "a91c567a-77e4-4f88-85a5-ffc7f06fcfcd";
      microsoftOptions.ClientSecret = "OqK8Q~dtKyPwTPs8G5hB8LufuPQLdg_T2kM3Kds5";
      microsoftOptions.AuthorizationEndpoint =
          $"https://login.microsoftonline.com/d6b996a5-844a-4ce4-b1e0-c9609c1ed43f/oauth2/v2.0/authorize";
      microsoftOptions.TokenEndpoint =
          $"https://login.microsoftonline.com/d6b996a5-844a-4ce4-b1e0-c9609c1ed43f/oauth2/v2.0/token";

    });
  }
}