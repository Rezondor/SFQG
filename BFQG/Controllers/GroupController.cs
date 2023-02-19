using Microsoft.AspNetCore.Mvc;

namespace BFQG.Controllers;

[ApiController]
[Route("api/groups")]
public class GroupController : Controller
{
    [NonAction]
    public IActionResult Index()
    {
        return View();
    }
}
