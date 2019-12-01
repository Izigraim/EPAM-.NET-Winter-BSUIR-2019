using System;
using System.Collections.Generic;
using System.Text;

namespace Task02.Models
{
    /// <summary>
    /// Instance of base account.
    /// </summary>
    internal class BaseAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="id">THe identifier.</param>
        /// <param name="user">The user.</param>
        public BaseAccount(string id, User user)
            : base(id, user)
        {
            this.costDeposite = 200;
            this.costBalance = this.costDeposite * 2;
        }

        /// <summary>
        /// Determines whether a balance transaction is possible or not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True or false.</returns>
        protected override bool ValidBalance(decimal value)
        {
            return value >= 0;
        }
    }
}
