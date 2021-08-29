using Entities.Dto;
using Entities.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class MakePayment
    {
        /// <summary>
        /// Stripe payment api's pay method
        /// </summary>
        /// <param name="payment">PaymentDto: email,token,sum,amount</param>
        /// <returns>Charge</returns>
        public static async Task<Charge> PayAsync(PaymentDto payment)
        {
            StripeConfiguration.ApiKey = Constants.PaymentSecretKey;

            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = await customers.CreateAsync(new CustomerCreateOptions
            {
                Email = payment.Email,
                Source = payment.Token
            });

            var charge = await charges.CreateAsync(new ChargeCreateOptions
            {
                Amount = (int)(payment.Sum * 100),
                Description = "Limak.az payment",
                Currency = "usd",
                Customer = customer.Id
            });

            return charge;

        }
    }
}
