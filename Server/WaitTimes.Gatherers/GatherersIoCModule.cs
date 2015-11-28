using System.Reflection;
using Autofac;
using WaitTimes.Gatherers.Adapters;
using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Gatherers
{
    public class GatherersIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(typeof(BaseTimeGathererAdapter).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
        
    }
}
