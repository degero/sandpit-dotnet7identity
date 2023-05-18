
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

public class StartupIdentityWeb
{


  public static void ConfigureServices(IServiceCollection services, ConfigurationManager Configuration)
  {
    IEnumerable<string>? initialScopes = Configuration["DownstreamApi:Scopes"]?.Split(' ');
    services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(Configuration, "AzureAd");
    // can enable this to use the token cache for downstream api calls
    // .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
    //     .AddDownstreamWebApi("DownstreamApi", Configuration.GetSection("DownstreamApi"))
    //     .AddInMemoryTokenCaches();

    services.AddRazorPages()
     .AddMvcOptions(options =>
     {
       // Secure all pages
       //  var policy = new AuthorizationPolicyBuilder()
       //                  .RequireAuthenticatedUser()
       //                  .Build();
       //  options.Filters.Add(new AuthorizeFilter(policy));
     })
     .AddMicrosoftIdentityUI();
  }

}