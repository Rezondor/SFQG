using Microsoft.AspNetCore.Mvc;

namespace BFQG.Controllers;

[ApiController]
[Route("[controller]")]
public class GetTypesController : Controller
{
    public GetTypesController(DbforqgsContext context)
    {
    }

}
