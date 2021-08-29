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
        private readonly Mock<FakeUserManager> _mockUserManager;
        private readonly Mock<IExpiredVerifyEmailTokenService> _mockExpiredVerifyEmailTokenService;
        private readonly Mock<IResetPasswordExpiredTokenService> _mockResetPasswordExpiredTokenService;
        public Mock<IConfiguration> mockConfiguration { get; }
        private readonly AuthenticateController _authenticateController;
        private List<AppUser> _appUsers;

        public AuthenticateControllerTest()
        {
            _mockUserManager = new Mock<FakeUserManager>();
            _mockExpiredVerifyEmailTokenService = new Mock<IExpiredVerifyEmailTokenService>();
            _mockResetPasswordExpiredTokenService = new Mock<IResetPasswordExpiredTokenService>();
            mockConfiguration = new Mock<IConfiguration>();
            _authenticateController = new AuthenticateController(_mockUserManager.Object, _mockExpiredVerifyEmailTokenService.Object
                , _mockResetPasswordExpiredTokenService.Object, mockConfiguration.Object);
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

        [Fact]
        public async Task VerifyEmail_IdIsNull_ReturnsBadRequestObject()
        {
            var verifyEmailDto = new VerifyEmailDto
            {
                Id = null,
                Token = ""
            };

            var result = await _authenticateController.VerifyEmail(verifyEmailDto);

            var error = Assert.IsType<ObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Fact]
        public async Task VerifyEmail_TokenIsNull_ReturnsBadRequestObject()
        {
            var verifyEmailDto = new VerifyEmailDto
            {
                Id = "12",
                Token = null
            };

            var result = await _authenticateController.VerifyEmail(verifyEmailDto);

            var error = Assert.IsType<ObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Theory]
        [InlineData("1")]
        public async Task VerifyEmail_IdIsInValid_ReturnsNotFound(string id)
        {
            AppUser user = null;

            _mockUserManager.Setup(service => service.FindByIdAsync(id)).ReturnsAsync(user);

            var verifyEmailDto = new VerifyEmailDto
            {
                Id = id,
                Token = ""
            };

            var result = await _authenticateController.VerifyEmail(verifyEmailDto);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, error.StatusCode);
        }

        [Theory]
        [InlineData("as-12","1234ak")]
        public async Task VerifyEmail_EmailIsVerified_ReturnsOkObjectResult(string id, string token)
        {
            var verifyEmailDto = new VerifyEmailDto
            {
                Id = id,
                Token = token
            };

            IdentityResult identityResult = new IdentityResult();

            _mockUserManager.Setup(service => service.FindByIdAsync(id)).ReturnsAsync(_appUsers.First());
            _mockUserManager.Setup(service => service.ConfirmEmailAsync(_appUsers.First(), token)).ReturnsAsync(identityResult);

            var result = await _authenticateController.VerifyEmail(verifyEmailDto);

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal<int>(200, (int)okResult.StatusCode);
        }
    }
}
