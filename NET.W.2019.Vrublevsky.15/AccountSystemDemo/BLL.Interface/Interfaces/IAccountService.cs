using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="accountType">The type of account.</param>
        /// <param name="id">The identifier.</param>
        void OpenAccount(User user, AccountType accountType, out string id);

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void CloseAccount(string id);

        /// <summary>
        /// Deposities the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        void Deposite(string id, decimal value);

        /// <summary>
        /// Withdraws the value.
        /// </summary>
        /// <param name="id">The Identifier.</param>
        /// <param name="value">The value.</param>
        void Withdraw(string id, decimal value);

        /// <summary>
        /// Gets info about account.
        /// </summary>
        /// <param name="id">The indentifier.</param>
        /// <returns>The string that represent account info.</returns>
        string Info(string id);
    }
}
