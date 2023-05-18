using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace aspnet7identity.Pages;

[Authorize]
public class SecurePageModel : PageModel
{
  public void OnGet()
  {
  }
}