using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instance of Platinum Account.
    /// </summary>
    public class PlatinumAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="accountType">The account type.</param>
        /// <param name="status">The status.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonus">The bonus.</param>
        public PlatinumAccount(User user, AccountType accountType, AccountStatus status, decimal balance, int bonus)
            : base(user, accountType, status, balance, bonus)
        {
            this.costDeposite = 10;
            this.costBalance = this.costDeposite * 2;
            this.AccountType = accountType;
            this.Status = status;
            this.balance = balance;
            this.bonusPoints = bonus;
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
