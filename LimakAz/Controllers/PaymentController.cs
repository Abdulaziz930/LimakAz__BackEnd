using AutoMapper;
using Buisness.Abstract;
using ClosedXML.Excel;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace LimakAz.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public PaymentController(UserManager<AppUser> userManager
            , IMapper mapper, ITransactionService transactionService)
        {
            _userManager = userManager;
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpPost("increaseBalance")]
        public async Task<IActionResult> IncreaseBalance([FromBody] PaymentDto payment)
        {
            try
            {
                if (payment.Amount > 50 || payment.Amount < 0)
                    return BadRequest(new ResponseDto { Status = "Error", Message = "Amount should be betwwen 0-50 usd" });

                if (payment.Email == null)
                    return BadRequest(new ResponseDto { Status = "Email address cannot be empty" });

                var user = await _userManager.FindByEmailAsync(payment.Email);
                if (user == null)
                    return NotFound();

                var oldBalance = user.Balance;

                var charge = await MakePayment.PayAsync(payment);

                if (charge.Paid)
                {
                    user.Balance = (decimal)(payment.Sum);
                    await _userManager.UpdateAsync(user);

                    var transaction = new Transaction
                    {
                        OldBalance = oldBalance,
                        Amount = (decimal)payment.Amount,
                        DateTime = DateTime.Now,
                        AppUserId = user.Id
                    };

                    await _transactionService.AddAsync(transaction);

                    return Ok(new ResponseDto { Status = "Success", Message = "Payment is successful " });
                }
                else
                {
                    return BadRequest(new ResponseDto { Status = "Error", Message = "Payment failed" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getTransactions/{userName}")]
        public async Task<IActionResult> GetTransactions([FromRoute] string userName, [FromQuery] int? page = 1)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            if (page == null)
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var allTransactions = await _transactionService.GetAllTransactionAsync(user.Id);
            if (allTransactions == null)
                return NotFound();

            var result = Decimal.Ceiling((decimal)allTransactions.Count / 5);

            if (result < page || page <= 0)
                return NotFound();

            var transactions = await _transactionService.GetAllTransactionAsync(user.Id, page.Value);
            if (transactions == null)
                return NotFound();

            var transactionDto = _mapper.Map<List<TransactionDto>>(transactions);

            return Ok(transactionDto);
        }

        [HttpGet("getTransactionsCount/{userName}")]
        public async Task<IActionResult> GetTransactionsCount([FromRoute] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var transactions = await _transactionService.GetAllTransactionAsync(user.Id);
            if (transactions == null)
                return NotFound();

            var result = Decimal.Ceiling((decimal)transactions.Count / 5);

            return Ok(result);
        }

        [HttpGet("getTransactionDetail/{userName}/{id}")]
        public async Task<IActionResult> GetTransactionDetail([FromRoute] string userName, int? id)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            if (id == null)
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var transaction = await _transactionService.GetTransactionAsync(user.Id, id.Value);
            if (transaction == null)
                return NotFound();

            var transactionDto = new TransactionDetailDto
            {
                OldBalance = transaction.OldBalance,
                Amount = transaction.Amount,
                NewBalance = transaction.OldBalance + transaction.Amount,
                DateTime = transaction.DateTime
            };

            return Ok(transactionDto);
        }

        [HttpGet("getAllTransactions/{userName}")]
        public async Task<IActionResult> GetAllTransactions([FromRoute] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var transactions = await _transactionService.GetAllTransactionAsync(user.Id);
            if (transactions == null)
                return NotFound();

            var transactionsDto = new List<TransactionExcelDto>();
            foreach (var transaction in transactions)
            {
                var transactionDto = new TransactionExcelDto
                {
                    Id = transaction.Id,
                    OldBalance = transaction.OldBalance,
                    Amount = transaction.Amount,
                    DateTime = transaction.DateTime.ToString("dd/MM/yyyy hh:mm:ss")
                };
                transactionsDto.Add(transactionDto);
            }

            return Ok(transactionsDto);
        }

    }
}
