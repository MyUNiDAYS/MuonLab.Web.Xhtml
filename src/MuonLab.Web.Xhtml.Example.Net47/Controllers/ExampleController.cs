using Microsoft.AspNetCore.Mvc;

namespace MuonLab.Web.Xhtml.Example.Net47.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
