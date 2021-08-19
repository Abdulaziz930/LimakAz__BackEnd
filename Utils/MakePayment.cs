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
        public static async Task<Charge> PayAsync(PaymentDto payment)
        {
                StripeConfiguration.ApiKey = Constants.PaymentSecretKey;

                var optionsToken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = payment.CardNumber,
                        ExpMonth = payment.Mounth,
                        ExpYear = payment.Year,
                        Cvc = payment.Cvc
                    }
                };

                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(optionsToken);

                var options = new ChargeCreateOptions
                {
                    Amount = payment.Amount,
                    Currency = "usd",
                    Description = "test",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                return charge;
            
        }
    }
}
