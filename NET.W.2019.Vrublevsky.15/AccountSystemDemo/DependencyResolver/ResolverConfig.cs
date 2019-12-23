using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
// using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<BankAccountService>();
            kernel.Bind<IStorage>().To<FakeStorage>();
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreate>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
