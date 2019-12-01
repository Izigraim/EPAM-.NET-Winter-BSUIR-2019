using System;
using System.Collections.Generic;
using System.Text;
using Task02.Models;
using Task02.Storages;

namespace Task02.Storages
{
    /// <summary>
    /// Storage based on list.
    /// </summary>
    internal class Storage : IStorage
    {
        private List<BankAccount> bankAccounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Storage"/> class.
        /// </summary>
        public Storage()
        {
            this.bankAccounts = new List<BankAccount>();
        }

        /// <summary>
        /// Create a bank account.
        /// </summary>
        /// <param name="bankAccount">The account.</param>
        public void Create(BankAccount bankAccount)
        {
            this.bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Uodates a bank account.
        /// </summary>
        /// <param name="bankAccount">The account.</param>
        public void Update(BankAccount bankAccount)
        {
            int i = this.bankAccounts.FindIndex(c => c.Id == bankAccount.Id);
            this.bankAccounts.RemoveAt(i);
            this.bankAccounts.Insert(i, bankAccount);
        }

        /// <summary>
        /// Gets the bank account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="BankAccount"/></returns>
        public BankAccount GetById(string id)
        {
            int i = this.bankAccounts.FindIndex(c => c.Id == id);
            return this.bankAccounts[i];
        }
    }
}
