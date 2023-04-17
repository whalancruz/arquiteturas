
using Interfaces.Services;
using Ninject.Modules;
using Services;

namespace Util.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfiguration>().ToConstant(new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build());
            Bind<ITesteServices>().To<TesteServices>();
        }
    }

}