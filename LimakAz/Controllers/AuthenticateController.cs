using Buisness.Abstract;
using DataAccess;
using DataAccess.Identity;
using EduHome.Areas.AdminPanel.Utils;
using Entities.Dto;
using Entities.Models;
using Google.Apis.Auth;
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
using Utils;

namespace LimakAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IExpiredVerifyEmailTokenService _expiredVerifyEmailTokenService;
        private readonly IResetPasswordExpiredTokenService _resetPasswordExpiredTokenService;
        //private readonly AppDbContext _dbContext;
        public IConfiguration Configuration { get; }
        public AuthenticateController(UserManager<AppUser> userManager
            , IExpiredVerifyEmailTokenService expiredVerifyEmailTokenService
            , IResetPasswordExpiredTokenService resetPasswordExpiredTokenService 
            , IConfiguration configuration /*AppDbContext dbContext*/)
        {
            _userManager = userManager;
            _expiredVerifyEmailTokenService = expiredVerifyEmailTokenService;
            _resetPasswordExpiredTokenService = resetPasswordExpiredTokenService;
            //_dbContext = dbContext;
            Configuration = configuration;
        }

        #region Register

        //POST: api/Authenticate/register
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

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var link = $"{Constants.ClientPort}/verify-email?id={user.Id}&token={token}";
            var title = "Verify E-Mail Address";
            var description = $"Welcome to Limak.az, {user.UserName}! To complete your Limak.az sign up, we just need to verify your email address";
            var buttonName = "Verify";
            var filePath = @"D:\Programming\CodeAcademy\FrontEnd\Templates\emailView2.html";

            var message = ViewConstant.GetEmailView(filePath, link, title, description, buttonName);
            await EmailUtil.SendEmailAsync(user.Email, message, "Limak.az - Verify Email Adress");

            return Ok(new ResponseDto { Status = "Success", Message = "Confirmation email sent" });
        }

        #endregion

        #region Login

        //POST: api/Authenticate/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, login.Password)))
                return Unauthorized(new ResponseDto { Status = "Error", Message = "Username or Password invalid" });

            if (!user.EmailConfirmed)
                return Unauthorized(new ResponseDto { Status = "Error", Message = "Your email address not verified" });

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
                expires: DateTime.UtcNow.AddMinutes(60),
                claims: authClaims,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo
            });
        }

        #endregion

        #region ForgotPassword

        //POST: api/Authenticate/forgotPassword
        //Send Email Reset Password's Link
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPassword)
        {
            if (string.IsNullOrEmpty(forgotPassword.Email))
                return BadRequest();

            var dbUser = await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (dbUser == null)
                return NotFound(new ResponseDto { Status = "Error", Message = "No user found matching this email" });

            if (!dbUser.EmailConfirmed)
                return Unauthorized(new ResponseDto { Status = "Error", Message = "Your email address not verified" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(dbUser);

            var link = $"{Constants.ClientPort}/reset-password?id={dbUser.Id}&token={token}";
            var title = "FORGOT YOUR PASSWORD?";
            var description = "Not to worry, we got you! Let’s get you a new password.";
            var buttonName = "Reset Password";

            var filePath = @"D:\Programming\CodeAcademy\FrontEnd\Templates\emailView2.html";

            var message = ViewConstant.GetEmailView(filePath ,link, title, description, buttonName);
            await EmailUtil.SendEmailAsync(dbUser.Email, message, "Limak.az - Reset Password");

            return Ok(new ResponseDto { Status = "Success", Message = "Email sent successfully" });
        }

        #endregion

        #region ResetPassword

        //POST: api/Authenticate/resetPassword
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

            if(await _resetPasswordExpiredTokenService.CheckExpiredVerifyEmailTokeAsync(resetPassword.Token))
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseDto { Status = "Bad Request", Message = "This link is expired" });

            var result = await _userManager.ResetPasswordAsync(dbUser, resetPassword.Token, resetPassword.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new ResponseDto { Status = error.Code, Message = error.Description });
                }
            }

            var expiredToken = new ResetPasswordExpiredToken
            {
                Token = resetPassword.Token
            };

            await _resetPasswordExpiredTokenService.AddAsync(expiredToken);

            return Ok(new ResponseDto { Status = "Success", Message = "Password has been successfully updated" });
        }

        #endregion

        #region VerifyEmail

        //POST: api/Authenticate/verifyEmail
        [HttpPost("verifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDto verifyEmail)
        {
            if (verifyEmail.Id == null || verifyEmail.Token == null)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseDto { Status = "Bad Request", Message = "Email or Token is Null" });

            var isExist = await _expiredVerifyEmailTokenService.GetExpiredVerifyEmailTokeAsync(verifyEmail.Token);
            if (isExist)
                return StatusCode(StatusCodes.Status400BadRequest,
                    new ResponseDto { Status = "Bad Request", Message = "This e-mail alredy verified" });

            var user = await _userManager.FindByIdAsync(verifyEmail.Id);
            if (user == null)
                return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, verifyEmail.Token);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "InvalidToken")
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        var link = $"{Constants.ClientPort}/verify-email?id={user.Id}&token={token}";
                        var title = "Verify E-Mail Address";
                        var description = $"Welcome to Limak.az, {user.UserName}! To complete your Limak.az sign up, we just need to verify your email address";
                        var buttonName = "Verify";

                        var filePath = @"D:\Programming\CodeAcademy\FrontEnd\Templates\emailView2.html";

                        var message = ViewConstant.GetEmailView(filePath, link, title, description, buttonName);
                        await EmailUtil.SendEmailAsync(user.Email, message, "Limak.az - Verify Email Adress");
                    }
                    return StatusCode(StatusCodes.Status403Forbidden,
                        new ResponseDto { Status = error.Code, Message = error.Description });
                }
            }

            var expiredToken = new ExpiredVerifyEmailToken
            {
                Token = verifyEmail.Token
            };

            await _expiredVerifyEmailTokenService.AddAsync(expiredToken);

            return Ok(new ResponseDto { Status = "Success", Message = "Email has been confirmed" });
        }

        #endregion

        #region ChangePassword

        //POST: api/Authenticate/changePassword
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePassword)
        {
            var user = await _userManager.FindByNameAsync(changePassword.UserName);
            if (user == null)
                return NotFound();

            if (!await _userManager.CheckPasswordAsync(user, changePassword.OldPassword))
                return Unauthorized(new ResponseDto { Status = "Error", Message = "Old password is not valid." });

            var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
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

        #endregion

        #region GoogleAuth

        //POST: api/Authenticate/externalLogin
        [HttpPost("externalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
        {
            var payload = await VerifyGoogleToken.VerifyGoogleTokenAsync(externalAuth, Configuration["Authentication:Google:ClientId"]);
            if (payload == null)
                return BadRequest(new ResponseDto { Status = "Error", Message = "Invalid External Authentication." });

            var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if(user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if(user == null)
                {
                    user = new AppUser 
                    { 
                        Email = payload.Email, 
                        UserName = payload.Name, 
                        Name = payload.GivenName, 
                        Surname = payload.FamilyName
                    };
                    try
                    {
                        await _userManager.CreateAsync(user);
                        //await _dbContext.Users.AddAsync(user);
                        //await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e);
                    }

                    await _userManager.AddToRoleAsync(user, RoleConstants.MemberRole);
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            if (user == null)
                return BadRequest("Invalid External Authentication.");

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:Issuer"],
                audience: Configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddMinutes(60),
                claims: authClaims,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
            );


            return Ok(new AuthResponseDto 
            { 
                Token = new JwtSecurityTokenHandler().WriteToken(token), 
                IsAuthSuccessful = true,
                Expires = token.ValidTo,
            });
        }

        #endregion
    }
}
