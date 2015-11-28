using System.Reflection;
using Autofac;
using WaitTimes.Core.Configuration;

namespace WaitTimes.Core
{
    public class CoreIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(typeof(TypedConfiguration).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
        
    }
}
