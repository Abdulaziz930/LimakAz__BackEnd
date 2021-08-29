using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class RandomUtil
    {
        private static Random random = new Random();

        /// <summary>
        /// Genrates random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns>string</returns>
        public static string RandomStringGenerator(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
