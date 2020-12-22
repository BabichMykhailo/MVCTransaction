using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransactionMVC.Startup))]
namespace TransactionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
