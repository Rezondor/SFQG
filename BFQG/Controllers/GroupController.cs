using Microsoft.AspNetCore.Mvc;

namespace BFQG.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : Controller
{
    [NonAction]
    public IActionResult Index()
    {
        return View();
    }
}
