using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeStorage : IStorage
    {
        private readonly List<BankAccount> list;

        public FakeStorage()
        {
            this.list = new List<BankAccount>();
        }

        public void Create(BankAccount bankAccount)
        {
            this.list.Add(bankAccount);
        }

        public List<BankAccount> GetAllAccounts()
        {
            return this.list;
        }

        public BankAccount GetById(string id)
        {
            return this.list[this.list.FindIndex(c => c.Id == id)];
        }

        public void Update(BankAccount bankAccount)
        {
            int indexOfUpdatedAccount = this.list.FindIndex(c => c.Id == bankAccount.Id);
            this.list.RemoveAt(indexOfUpdatedAccount);
            this.list.Insert(indexOfUpdatedAccount, bankAccount);
        }
    }
}
