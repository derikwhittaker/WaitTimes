using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Services.ThemeParks
{

    public interface IHollywoodStudiosService : IThemeParkService
    {

    }

    public class HollywoodStudiosService : BaseThemeParkService, IHollywoodStudiosService
    {

        public HollywoodStudiosService(IHollywoodStudiosAdapter serviceAdapter, ITypedConfiguration typedConfiguration)
            : base(serviceAdapter, typedConfiguration)
        {
        }

        public void CurrentTimes()
        {
            //var currentTimes = _serviceAdapter.CurrentTimes();
        }
        
        public override string LocationZipCode => "32830"; // needs to be pulled from config file
    }
}