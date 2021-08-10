using Buisness.Abstract;
using DataAccess.Identity;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public IConfiguration Configuration { get; }
        public AuthenticateController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            Configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            var isExistUsername = await _userManager.FindByNameAsync(register.UserName);
            if (isExistUsername != null)
                return StatusCode(StatusCodes.Status409Conflict,
                    new ResponseDto { Status = "Username Error", Message = "This username already exists" });
            var isExistEmail = await _userManager.FindByEmailAsync(register.Email);
            if (isExistEmail != null)
                return StatusCode(StatusCodes.Status409Conflict,
                    new ResponseDto { Status = "Email Error", Message = "This email already exists" });

            var user = new AppUser
            {
                UserName = register.UserName,
                Name = register.Name,
                Surname = register.Surname,
                Email = register.Email,
                City = register.City,
                SerialNumber = register.SerialNumber,
                FinCode = register.FinCode,
                Gender = register.Gender,
                Address = register.Address,
                PhoneNumber = register.PhoneNumber,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new ResponseDto { Status = error.Code, Message = error.Description });
                }
            }

            await _userManager.AddToRoleAsync(user, RoleConstants.MemberRole);

            return Ok(new ResponseDto { Status = "Success", Message = $"{user.UserName} Successfully registered" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null && !(await _userManager.CheckPasswordAsync(user, login.Password)))
                return Unauthorized(new ResponseDto { Status = "Error", Message = "Username or Password invalid" });

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:Issuer"],
                audience: Configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(60),
                claims: authClaims,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { 
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo
            });
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.Where(x => x.IsActive == true).ToListAsync();
            if (users == null)
                return NotFound();

            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };
                usersDto.Add(userDto);
            }

            return Ok(usersDto);
        }
    }
}
