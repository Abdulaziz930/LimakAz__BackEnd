using AutoMapper;
using Buisness.Abstract;
using Entities.Dto;
using Entities.Models;
using LimakAz.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LimakAz.Test
{
    public class PaymentContollerTest
    {
        private readonly Mock<FakeUserManager> _mockUserManager;
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PaymentController _paymentContoller;
        private List<AppUser> _appUsers;
        private PaymentDto _paymentDto;
        private DecreaseBalanceDto _decreaseBalance;

        public PaymentContollerTest()
        {
            _mockUserManager = new Mock<FakeUserManager>();
            _mockTransactionService = new Mock<ITransactionService>();
            _mockMapper = new Mock<IMapper>();
            _paymentContoller = 
                new PaymentController(_mockUserManager.Object, _mockMapper.Object, _mockTransactionService.Object);
            _appUsers = new List<AppUser>()
            {
                new AppUser { Id = "as-12", Name = "test", Surname = "test" , UserName = "test1" , Email = "test1@email.com"
                , City = "Baku" , Address = "adres1", SerialNumber = 12345678, FinCode = "1234567" , EmailConfirmed = true
                , BirthDay = DateTime.Now},
                new AppUser { Id = "as-13", Name = "test", Surname = "test" , UserName = "test2" , Email = "test2@email.com"
                , City = "Baku" , Address = "adres1", SerialNumber = 12345678, FinCode = "1234567" , EmailConfirmed = true
                , BirthDay = DateTime.Now}
            };
            _paymentDto = new PaymentDto
            {
                Amount = 0,
                Token = "",
                Sum = 0,
                Email = ""
            };
            _decreaseBalance = new DecreaseBalanceDto
            {
                Amount = 0,
                ResultBalance = 0,
                UserName = ""
            };
        }

        [Theory]
        [InlineData(51, "example@gmail.com")]
        [InlineData(-1, "example@gmail.com")]
        public async Task IncreaseBalance_WrongAmount_ReturnsBadRequestObject(double amount, string email)
        {
            _paymentDto.Amount = amount;
            _paymentDto.Email = email;

            var result = await _paymentContoller.IncreaseBalance(_paymentDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Theory]
        [InlineData(20)]
        public async Task IncreaseBalance_EmailIsNull_ReturnsBadRequestObject(double amount)
        {
            _paymentDto.Email = null;
            _paymentDto.Amount = amount;

            var result = await _paymentContoller.IncreaseBalance(_paymentDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Theory]
        [InlineData("example@gmail.com",20)]
        public async Task IncreaseBalance_EmailIsInvalid_ReturnsNotFound(string email, double amount)
        {
            _paymentDto.Email = email;
            _paymentDto.Amount = amount;

            AppUser user = null;

            _mockUserManager.Setup(service => service.FindByEmailAsync(_paymentDto.Email))
                .ReturnsAsync(user);

            var result = await _paymentContoller.IncreaseBalance(_paymentDto);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, (int)error.StatusCode);
        }

        [Theory]
        [InlineData(20, "test1@email.com")]
        public async Task IncreaseBalance_TokenIsInvalid_ReturnsBadRequestObject(double amount, string email)
        {
            _paymentDto.Email = email;
            _paymentDto.Amount = amount;

            _mockUserManager.Setup(service => service.FindByEmailAsync(_paymentDto.Email))
                .ReturnsAsync(_appUsers.First());

            var result = await _paymentContoller.IncreaseBalance(_paymentDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Fact]
        public async Task DecreaseBalance_UserNameIsNull_ReturnsBadRequestObject()
        {
            _decreaseBalance.UserName = null;

            var result = await _paymentContoller.DecreaseBalance(_decreaseBalance);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Theory]
        [InlineData("test5")]
        public async Task DecreaseBalance_UserNameIsInValid_ReturnsNotFound(string userName)
        {
            _decreaseBalance.UserName = userName;

            AppUser user = null;

            _mockUserManager.Setup(service => service.FindByNameAsync(_decreaseBalance.UserName))
                .ReturnsAsync(user);

            var result = await _paymentContoller.DecreaseBalance(_decreaseBalance);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, (int)error.StatusCode);
        }

        [Theory]
        [InlineData(5,10,"test1")]
        public async Task DecreaseBalance_BalanceIsDecreased_ReurnsOkObject(double resultBalance, double amount
            , string userName)
        {
            _decreaseBalance.UserName = userName;
            _decreaseBalance.ResultBalance = resultBalance;
            _decreaseBalance.Amount = amount;

            _mockUserManager.Setup(service => service.FindByNameAsync(_decreaseBalance.UserName))
                .ReturnsAsync(_appUsers.First());

            var result = await _paymentContoller.DecreaseBalance(_decreaseBalance);

            var okResult = Assert.IsType<OkObjectResult>(result);
        }
    }
}
