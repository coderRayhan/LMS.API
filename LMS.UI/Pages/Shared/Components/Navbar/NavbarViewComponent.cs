using Microsoft.AspNetCore.Mvc;

namespace LMS.UI.Pages.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
