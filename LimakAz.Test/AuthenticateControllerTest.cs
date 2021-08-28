using Buisness.Abstract;
using Entities.Dto;
using Entities.Models;
using LimakAz.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LimakAz.Test
{
    public class AuthenticateControllerTest
    {
        private readonly Mock<UserManager<AppUser>> _mockUserManager;
        private readonly Mock<IExpiredVerifyEmailTokenService> _mockExpiredVerifyEmailTokenService;
        private readonly Mock<IResetPasswordExpiredTokenService> _mockResetPasswordExpiredTokenService;
        public Mock<IConfiguration> mockConfiguration { get; }
        private readonly AuthenticateController _authenticateController;
        private List<AppUser> _appUsers;
        private LoginDto _loginDto;


        public AuthenticateControllerTest()
        {
            _mockUserManager = new Mock<UserManager<AppUser>>();
            _mockExpiredVerifyEmailTokenService = new Mock<IExpiredVerifyEmailTokenService>();
            _mockResetPasswordExpiredTokenService = new Mock<IResetPasswordExpiredTokenService>();
            mockConfiguration = new Mock<IConfiguration>();
            _authenticateController = new AuthenticateController(_mockUserManager.Object, _mockExpiredVerifyEmailTokenService.Object 
                , _mockResetPasswordExpiredTokenService.Object , mockConfiguration.Object);
            _appUsers = new List<AppUser>()
            {
                new AppUser { Id = "as-12", Name = "test", Surname = "test" , UserName = "test1" , Email = "test1@email.com"
                , City = "Baku" , Address = "adres1", SerialNumber = 12345678, FinCode = "1234567" , EmailConfirmed = true
                , BirthDay = DateTime.Now},
                new AppUser { Id = "as-13", Name = "test", Surname = "test" , UserName = "test2" , Email = "test2@email.com"
                , City = "Baku" , Address = "adres1", SerialNumber = 12345678, FinCode = "1234567" , EmailConfirmed = true
                , BirthDay = DateTime.Now}
            };
        }

        [Theory]
        [InlineData(null,"123")]
        public async Task Login_UserIsNull_ReturnUnauthorizedObject(string userName, string password)
        {
            AppUser appUser = null;
             
            _mockUserManager.Setup(service => service.FindByNameAsync(userName)).ReturnsAsync(appUser);

            _loginDto = new LoginDto
            {
                UserName = userName,
                Password = password
            };

            var login = await _authenticateController.Login(_loginDto);

            var error = Assert.IsType<UnauthorizedObjectResult>(login);
        }


    }
}
