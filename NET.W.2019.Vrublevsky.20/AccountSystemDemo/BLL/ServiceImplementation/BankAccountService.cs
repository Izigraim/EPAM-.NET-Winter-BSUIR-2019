using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Fake.Repositories;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Repositories;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Service to work with bank accounts.
    /// </summary>
    public class BankAccountService : IAccountService
    {
        private IStorage bankAccounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountService"/> class.
        /// </summary>
        public BankAccountService(BankAccountContext context)
        {
            this.bankAccounts = new DbStorage(context);
        }

        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="accountType">The type of account.</param>
        /// <param name="id">The identifier.</param>
        public void OpenAccount(User user, AccountType accountType, out int id)
        {
            BankAccount bankAccount;

            switch ((int)accountType)
            {
                case 0:
                    {
                        bankAccount = new BaseAccount(user, accountType, AccountStatus.Open, 0, 0);
                        break;
                    }

                case 1:
                    {
                        bankAccount = new GoldAccount(user, accountType, AccountStatus.Open, 0, 0);
                        break;
                    }

                case 2:
                    {
                        bankAccount = new PlatinumAccount(user, accountType, AccountStatus.Open, 0, 0);
                        break;
                    }

                default:
                    {
                        bankAccount = new BaseAccount(user, accountType, AccountStatus.Open, 0, 0);
                        break;
                    }
            }

            bankAccount.Status = AccountStatus.Open;
            this.bankAccounts.Create(bankAccount);
            id = bankAccount.Id;
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void CloseAccount(int id)
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
        public void Deposite(int id, decimal value)
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
        public void Withdraw(int id, decimal value)
        {
            BankAccount bankAccount = this.bankAccounts.GetById(id);
            bankAccount.Withdraw(value);
            this.bankAccounts.Update(bankAccount);
        }

        /// <summary>
        /// Gets info about account.
        /// </summary>
        /// <param name="id">The indentifier.</param>
        /// <returns>The string that represent account info.</returns>
        public string Info(int id)
        {
            BankAccount bankAccount = this.bankAccounts.GetById(id);
            return bankAccount.ToString();
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>All accounts.</returns>
        public List<BankAccount> GetAllAccounts()
        {
            return this.bankAccounts.GetAllAccounts();
        }
    }
}
