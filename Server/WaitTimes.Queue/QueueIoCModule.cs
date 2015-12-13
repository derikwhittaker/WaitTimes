using System.Reflection;
using Autofac;
using WaitTimes.Queue.Publishers;

namespace WaitTimes.Queue
{
    public class QueueIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(typeof(IParkRecalculationPublisher).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
        
    }
}
