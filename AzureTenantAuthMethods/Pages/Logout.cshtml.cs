using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace aspnet7identity.Pages;

[AllowAnonymous]
public class LogoutModel : PageModel
{
  public async Task<ActionResult> OnGet()
  {
    // await _signInManager.SignOutAsync();
    //    await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/Index" });
    await HttpContext.SignOutAsync();
    return RedirectToPage("./Index");
  }
}