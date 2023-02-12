using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BFQG.Services;

public class AccountService : IAccountService
{
    private readonly IBaseRepository<UserModel> _userRepository;
    public AccountService(IBaseRepository<UserModel> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterUserModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким логином уже есть",
                };
            }

            user = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Patronomic = model.Patronomic,
                Course = model.Course,
                GroupId = model.GroupId,
                Role = model.Role,
                Password = HashPasswordHelper.HashPassword(model.Password),
            };

            await _userRepository.Create(user);

            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Объект добавился",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<BaseResponse<ClaimsIdentity>> Login(LoginUserModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь не найден"
                };
            }

            if (user.Password != HashPasswordHelper.HashPassword(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Неверный пароль или логин"
                };
            }
            var result = Authenticate(user);

            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    private ClaimsIdentity Authenticate(UserModel user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
        };
        return new ClaimsIdentity(claims, "ApplicationCookie",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }
}

