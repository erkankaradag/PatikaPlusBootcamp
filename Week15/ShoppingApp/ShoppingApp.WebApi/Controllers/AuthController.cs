using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.WebApi.Jwt;
using ShoppingApp.WebApi.Models;
using ShoppingApp.Business.Operations.User;
using ShoppingApp.Business.Operations.User.Dtos;
using ShoppingApp.WebApi.Jwt;
using ShoppingApp.WebApi.Models;

namespace ShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // registration process
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest data)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new Exception(errors);
            }

            var addUserDto = new AddUserDto
            {
                Email = data.Email,
                Password = data.Password,
                FirstName = data.FirstName,
                LastName = data.LastName,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userService.AddUser(addUserDto);

            if (!result.IsSucceed)
            {
                throw new Exception(result.Message);
            }

            return Ok(result.Message);
        }

        // login
        [HttpPost("login")]
        public IActionResult Login(LoginRequest data)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new Exception(errors);
            }

            var result = _userService.LoginUser(new LoginUserDto
            {
                Email = data.Email,
                Password = data.Password
            });

            if (!result.IsSucceed)
            {
                throw new Exception(result.Message);
            }

            var user = result.Data;
            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)
            });

            return Ok(new LoginResponse
            {
                Message = "Giriş başarılı",
                Token = token
            });
        }

    }
}