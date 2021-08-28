using Entities.Dto;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class VerifyGoogleToken
    {
        public static async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(ExternalAuthDto externalAuth, string configuration)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { configuration }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
