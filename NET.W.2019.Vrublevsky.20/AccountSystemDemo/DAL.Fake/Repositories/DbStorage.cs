using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Repositories;

namespace DAL.Fake.Repositories
{
    public class DbStorage : IStorage
    {
        private readonly BankAccountContext context;

        public DbStorage(BankAccountContext context)
        {
            this.context = context;
        }

        public void Create(BankAccount bankAccount)
        {
            this.context.BankAccounts.Add(bankAccount);
            this.context.SaveChanges();
        }

        public List<BankAccount> GetAllAccounts()
        {
            return this.context.BankAccounts.ToList();
        }

        public BankAccount GetById(int id)
        {
            return this.context.BankAccounts.Find(id);
        }

        public void Update(BankAccount bankAccount)
        {
            this.context.SaveChanges();
        }
    }
}
