﻿using System;
using System.Collections.Generic;
using System.Text;
using Task02.Models;
using Task02.Storages;

namespace Task02.Logic
{
    /// <summary>
    /// Service to work with bank accounts.
    /// </summary>
    internal class BankAccountService
    {
        private IStorage bankAccounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountService"/> class.
        /// </summary>
        public BankAccountService()
        {
            this.bankAccounts = new Storage();
        }

        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="accountType">The type of account.</param>
        /// <param name="id">The identifier.</param>
        public void OpenAccount(User user, AccountType accountType, out string id)
        {
            BankAccount bankAccount;
            id = this.GenerateAccountId(user.ToString() + " " + accountType.ToString());

            switch ((int)accountType)
            {
                case 0:
                    {
                        bankAccount = new BaseAccount(id, user);
                        break;
                    }

                case 1:
                    {
                        bankAccount = new GoldAccount(id, user);
                        break;
                    }

                case 2:
                    {
                        bankAccount = new PlatinumAccount(id, user);
                        break;
                    }

                default:
                    {
                        bankAccount = new BaseAccount(id, user);
                        break;
                    }
            }

            bankAccount.Status = AccountStatus.Open;
            this.bankAccounts.Create(bankAccount);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void CloseAccount(string id)
        {
            BankAccount bankAccount = this.bankAccounts.GetById(id);
            if (bankAccount.Status == AccountStatus.Closed)
            {
                throw new ArgumentException("This account is already closed.", nameof(id));
            }

            bankAccount.Status = AccountStatus.Closed;
            this.bankAccounts.Update(bankAccount);
        }

        /// <summary>
        /// Deposities the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void Deposite(string id, decimal value)
        {
            BankAccount bankAccount = this.bankAccounts.GetById(id);
            bankAccount.Deposite(value);
            this.bankAccounts.Update(bankAccount);
        }

        /// <summary>
        /// Withdraws the value.
        /// </summary>
        /// <param name="id">The Identifier.</param>
        /// <param name="value">The value.</param>
        public void Withdraw(string id, decimal value)
        {
            BankAccount bankAccount = this.bankAccounts.GetById(id);
            bankAccount.Withdraw(value);
            this.bankAccounts.Update(bankAccount);
        }

        /// <summary>
        /// Gets info about account.
        /// </summary>
        /// <param name="id">The indentifier.</param>
        /// <returns></returns>
        public string Info(string id)
        {
            BankAccount bankAccount = this.bankAccounts.GetById(id);
            return bankAccount.ToString();
        }

        /// <summary>
        /// Generates account identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A <see cref="System.String"/> that used as identifier.</returns>
        private string GenerateAccountId(string key)
        {
            return Math.Abs(key.GetHashCode()).ToString();
        }
    }
}
