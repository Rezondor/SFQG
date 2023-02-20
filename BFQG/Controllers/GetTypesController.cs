using Microsoft.AspNetCore.Mvc;

namespace BFQG.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetTypesController : Controller
{
    public GetTypesController(DbforqgsContext context)
    {
    }

}
