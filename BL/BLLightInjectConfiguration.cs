using DAL;
using DAL.Repositories;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BLLightInjectConfiguration
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register<TransactionMVCContext>(new PerScopeLifetime());
            container.Register<ITransactionRepository, TransactionRepository>();
            container.Register<ICategoryRepository, CategoryRepository>();

            return container;
        }
    }
}
