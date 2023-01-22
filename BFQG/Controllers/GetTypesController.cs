using BFQG.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BFQG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetTypesController : Controller
    {
        private readonly DbforqgsContext _context;
        public GetTypesController(DbforqgsContext context)
        {
            _context= context;
        }
        [HttpGet("getAllAccountTypes")]
        public IEnumerable<AccountType> GetTypes() 
        {
            
            return _context.AccountTypes.ToList();
        }
    }
}
