using System.Reflection;
using Autofac;
using WaitTimes.Services.ThemeParks;

namespace WaitTimes.Services
{
    public class DisneyLandIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Gatherers.GatherersIoCModule());
            
            builder.RegisterAssemblyTypes(typeof(DisneyLandService).GetTypeInfo().Assembly).AsImplementedInterfaces();
      
        }
    }
}
