using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BFQG.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserModel model)
    {

        var response = await _accountService.Register(model);
        if (response.StatusCode == Enum.StatusCode.OK)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(response.Data));
            return Ok();
        }
        return BadRequest(response.Data);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserModel user)
    {
        var response = await _accountService.Login(user);

        if (response.StatusCode == Enum.StatusCode.OK)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

            return Ok();
        }
        return BadRequest(response.Data);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }
}
