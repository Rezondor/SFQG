using BFQG.Models;
using BFQG.Response;
using System.Security.Claims;

namespace BFQG.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Login(LoginUser model);
    }
}
