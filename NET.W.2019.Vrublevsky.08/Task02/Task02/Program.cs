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

            bankAccountService.OpenAccount(new User("Ilya", "Vrublevsky"), AccountType.Platinum, out string id);
            Console.WriteLine(bankAccountService.Info(id));
            bankAccountService.Deposite(id, 100);
            Console.WriteLine(bankAccountService.Info(id));
            bankAccountService.Withdraw(id, 10);
            Console.WriteLine(bankAccountService.Info(id));
            bankAccountService.CloseAccount(id);
            Console.WriteLine(bankAccountService.Info(id));
        }
    }
}
