using System;
using System.Collections.Generic;
using System.Text;

namespace Task02.Models
{
    /// <summary>
    /// Instacne of Gold Account.
    /// </summary>
    internal class GoldAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public GoldAccount(string id, User user)
            : base(id, user)
        {
            this.costDeposite = 100;
            this.costBalance = this.costDeposite * 2;
        }

        /// <summary>
        /// Determines whether a balance transaction is possible or not.
        /// </summary>
        /// <param name="value">The value/</param>
        /// <returns>True or false.</returns>
        protected override bool ValidBalance(decimal value)
        {
            return value >= 0;
        }
    }
}
