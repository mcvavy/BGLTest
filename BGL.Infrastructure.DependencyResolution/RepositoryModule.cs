using BGL.Core.Interfaces;
using BGL.Infrastructure.Repository;
using Ninject.Modules;

namespace BGL.Infrastructure.DependencyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationContext>().To<ApplicationContext>();
        }
    }
}
