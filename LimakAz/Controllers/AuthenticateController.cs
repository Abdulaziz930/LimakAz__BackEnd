using Buisness.Abstract;
using DataAccess.Identity;
using EduHome.Areas.AdminPanel.Utils;
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
            if (user == null || !(await _userManager.CheckPasswordAsync(user, login.Password)))
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

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPassword)
        {
            if (string.IsNullOrEmpty(forgotPassword.Email))
                return BadRequest();

            var dbUser = await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (dbUser == null)
                return NotFound(new ResponseDto { Status = "Error", Message = "No user found matching this email" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(dbUser);

            var link = $"http://localhost:3000/reset-password?id={dbUser.Id}&token={token}";

            //var link = Url.Action("ForgotPassword", "Authenticate", new { dbUser.Id, token }, protocol: HttpContext.Request.Scheme);
            var message = $"<a href={link}>For Reset password click here</a>";
            await EmailUtil.SendEmailAsync(dbUser.Email, message, "ResetPassword");

            return Ok(new ResponseDto { Status = "Success", Message = "Email sent successfully" });
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPassword)
        {
            if (string.IsNullOrEmpty(resetPassword.Id))
                return BadRequest();

            if (string.IsNullOrEmpty(resetPassword.Token))
                return BadRequest();

            if (string.IsNullOrEmpty(resetPassword.Password))
                return BadRequest();

            if (string.IsNullOrEmpty(resetPassword.ConfirmPassword))
                return BadRequest();

            var dbUser = await _userManager.FindByIdAsync(resetPassword.Id);
            if (dbUser == null)
                return NotFound();

            var result = await _userManager.ResetPasswordAsync(dbUser, resetPassword.Token, resetPassword.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new ResponseDto { Status = error.Code, Message = error.Description });
                }
            }

            return Ok(new ResponseDto { Status = "Success", Message = "Password has been successfully updated" });
        }
    }
}
