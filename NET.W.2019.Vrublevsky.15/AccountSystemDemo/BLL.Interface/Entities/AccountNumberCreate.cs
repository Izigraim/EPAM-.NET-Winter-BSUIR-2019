using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class AccountNumberCreate : IAccountNumberCreateService
    {
        /// <summary>
        /// Generates account identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A <see cref="System.String"/> that used as identifier.</returns>
        public string GenerateAccountId(string key)
        {
            return Math.Abs(key.GetHashCode()).ToString();
        }
    }
}
