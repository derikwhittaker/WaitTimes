using System.Reflection;
using Autofac;
using WaitTimes.Persistance.FileStorage;
using WaitTimes.Persistance.Raven;

namespace WaitTimes.Persistance
{
    public class PersistanceIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(FlatFilePersister).GetTypeInfo().Assembly).AsImplementedInterfaces();
            
            builder.RegisterType<WeatherRepository>().As<IWeatherRepository>();
            
            builder.RegisterType<WaitTimesRepository>().As<IWaitTimesRepository>();

        }
        
    }
}
