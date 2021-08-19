using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace LimakAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public PaymentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("increaseBalance")]
        public async Task<IActionResult> IncreaseBalance([FromBody] PaymentDto payment)
        {
            try
            {
                var charge = await MakePayment.PayAsync(payment);

                if (charge.Paid)
                {
                    var user = await _userManager.FindByNameAsync(payment.UserName);
                    if (user == null)
                        return NotFound();

                    user.Balance += (decimal)(payment.Amount * 0.01 * 1.7);
                    await _userManager.UpdateAsync(user);

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
    }
}
