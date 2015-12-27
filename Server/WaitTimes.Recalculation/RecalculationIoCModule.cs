using System.Reflection;
using Autofac;
using WaitTimes.Recalculation.Recalculation;

namespace WaitTimes.Recalculation
{
    public class RecalculationIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IParkRecalculationService).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}
