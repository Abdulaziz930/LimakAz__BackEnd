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
        }

        [Theory]
        [InlineData(51)]
        [InlineData(-1)]
        public async Task IncreaseBalance_WrongAmount_ReturnsBadRequestObject(double amount)
        {
            var paymentDto = new PaymentDto
            {
                Amount = amount,
                Token = "",
                Sum = 0,
                Email = "example@gmail.com"
            };

            var result = await _paymentContoller.IncreaseBalance(paymentDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Fact]
        public async Task IncreaseBalance_EmailIsNull_ReturnsBadRequestObject()
        {
            var paymentDto = new PaymentDto
            {
                Amount = 20,
                Token = "",
                Sum = 0,
                Email = null
            };

            var result = await _paymentContoller.IncreaseBalance(paymentDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Theory]
        [InlineData("example@gmail.com")]
        public async Task IncreaseBalance_EmailIsInvalid_ReturnsNotFound(string email)
        {
            var paymentDto = new PaymentDto
            {
                Amount = 20,
                Token = "",
                Sum = 0,
                Email = email
            };

            AppUser user = null;

            _mockUserManager.Setup(service => service.FindByEmailAsync(paymentDto.Email))
                .ReturnsAsync(user);

            var result = await _paymentContoller.IncreaseBalance(paymentDto);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, (int)error.StatusCode);
        }

        [Fact]
        public async Task IncreaseBalance_TokenIsInvalid_ReturnsBadRequestObject()
        {
            var paymentDto = new PaymentDto
            {
                Amount = 20,
                Token = "",
                Sum = 0,
                Email = "test1@email.com"
            };

            _mockUserManager.Setup(service => service.FindByEmailAsync(paymentDto.Email))
                .ReturnsAsync(_appUsers.First());

            var result = await _paymentContoller.IncreaseBalance(paymentDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Fact]
        public async Task DecreaseBalance_UserNameIsNull_ReturnsBadRequestObject()
        {
            var decreaseDto = new DecreaseBalanceDto
            {
                UserName = null,
                ResultBalance = 0,
                Amount = 0
            };

            var result = await _paymentContoller.DecreaseBalance(decreaseDto);

            var error = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal<int>(400, (int)error.StatusCode);
        }

        [Theory]
        [InlineData("test5")]
        public async Task DecreaseBalance_UserNameIsInValid_ReturnsNotFound(string userName)
        {
            var decreaseDto = new DecreaseBalanceDto
            {
                UserName = userName,
                ResultBalance = 0,
                Amount = 0
            };

            AppUser user = null;

            _mockUserManager.Setup(service => service.FindByNameAsync(decreaseDto.UserName))
                .ReturnsAsync(user);

            var result = await _paymentContoller.DecreaseBalance(decreaseDto);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, (int)error.StatusCode);
        }

        [Theory]
        [InlineData(5,10,"test1")]
        public async Task DecreaseBalance_BalanceIsDecreased_ReurnsOkObject(double resultBalance, double amount
            , string userName)
        {
            var decreaseDto = new DecreaseBalanceDto
            {
                UserName = userName,
                ResultBalance = resultBalance,
                Amount = amount
            };

            _mockUserManager.Setup(service => service.FindByNameAsync(decreaseDto.UserName))
                .ReturnsAsync(_appUsers.First());

            var result = await _paymentContoller.DecreaseBalance(decreaseDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
        }
    }
}
