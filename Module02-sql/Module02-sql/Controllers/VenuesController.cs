using Microsoft.AspNetCore.Mvc;

namespace Module02_sql.Controllers
{
    public class VenuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
