using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace DAL.Interface.Interfaces
{
    public interface IStorage
    {
        void Create(BankAccount bankAccount);

        BankAccount GetById(int id);

        void Update(BankAccount bankAccount);

        List<BankAccount> GetAllAccounts();
    }
}
