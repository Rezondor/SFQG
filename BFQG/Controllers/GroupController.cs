using Microsoft.AspNetCore.Mvc;

namespace BFQG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
