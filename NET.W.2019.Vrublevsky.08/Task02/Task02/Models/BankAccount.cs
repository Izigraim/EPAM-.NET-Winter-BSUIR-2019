using System;
using System.Collections.Generic;
using System.Text;

namespace Task02.Models
{
    /// <summary>
    /// Instance of bank account.
    /// </summary>
    internal abstract class BankAccount
    {
        protected int costBalance;
        protected int costDeposite;

        private User user;
        private decimal balance;
        private int bonusPoints;

        protected BankAccount(string id, User user)
        {
            this.Id = id;
            this.user = user;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets ot sets the status.
        /// </summary>
        /// <value>
        /// Ot sets the status.
        /// </value>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// Deposite balance with value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Deposite(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("You cannot deposite your balance with a value equal to zero or less.", nameof(value));
            }

            this.bonusPoints += this.CountBonusPoints(value);
            this.balance += value;
        }

        /// <summary>
        /// Witdraw balance with value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Withdraw(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("You can't withdraw with a value equal to zero or less.", nameof(value));
            }

            if (!this.ValidBalance(this.balance - value))
            {
                throw new InvalidOperationException($"You can't withdraw {value}, because your actual balanc is {this.balance}");
            }

            this.bonusPoints -= this.CountBonusPoints(value);
            this.balance -= value;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Id.ToString() + " " + this.Status.ToString() + " " + this.user.ToString() + " " + this.balance.ToString() + " " + bonusPoints.ToString();
        }

        /// <summary>
        /// Counts the bonus.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Count of bonus.</returns>
        protected int CountBonusPoints(decimal value)
        {
            return (int)(this.balance * (1 / (decimal)this.costBalance) + value * (1 / (decimal)this.costDeposite));
        }

        /// <summary>
        /// Determines whether a balance transaction is possible or not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True or false.</returns>
        protected abstract bool ValidBalance(decimal value);
    }
}
