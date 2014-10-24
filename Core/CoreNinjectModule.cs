using System.Data.Entity;
using Core.Migrations;
using Core.Storage;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Core
{
    public class CoreNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<Configuration>()
                  .ToSelf()
                  .InRequestScope();

            Kernel.Bind<DbContext>()
                .To<AMFDbContext>()
                .InRequestScope();

            Kernel.Bind<ISession>()
                .To<EntitySession>()
                .InRequestScope();

            
        }
    }

}
