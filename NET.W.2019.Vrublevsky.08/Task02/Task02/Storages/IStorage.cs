using System;
using System.Collections.Generic;
using System.Text;
using Task02.Models;

namespace Task02.Storages
{
    /// <summary>
    /// Storage.
    /// </summary>
    internal interface IStorage
    {
        void Create(BankAccount bankAccount);

        BankAccount GetById(string id);

        void Update(BankAccount bankAccount);

        List<BankAccount> GetAllAccounts();
    }
}
