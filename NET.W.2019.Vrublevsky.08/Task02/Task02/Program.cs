using System;
using Task02.Logic;
using Task02.Models;
using Task02.Storages;

namespace Task02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BankAccountService bankAccountService = new BankAccountService();

            bankAccountService.OpenAccount(new User("asfasf", "safasf"), AccountType.Platinum);

            foreach (BankAccount bankAccount in bankAccountService.GetAllAccounts())
            {
                Console.WriteLine(bankAccount.ToString());
            }
        }
    }
}
