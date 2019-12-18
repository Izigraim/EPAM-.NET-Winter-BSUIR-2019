using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.ServiceImplementation;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IAccountService accountService = new BankAccountService();
            accountService.OpenAccount(new User("123", "123"), AccountType.Platinum, out string id);
            Console.WriteLine(accountService.Info(id));
            accountService.Deposite(id, 1000);
            accountService.Withdraw(id, 10);
            Console.WriteLine(accountService.Info(id));
            accountService.CloseAccount(id);
            Console.WriteLine(accountService.Info(id));
        }
    }
}
