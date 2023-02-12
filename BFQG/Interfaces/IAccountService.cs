using BFQG.Models.Auth;
using BFQG.Response;
using System.Security.Claims;

namespace BFQG.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Login(LoginUserModel model);
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterUserModel model);
    }
}
