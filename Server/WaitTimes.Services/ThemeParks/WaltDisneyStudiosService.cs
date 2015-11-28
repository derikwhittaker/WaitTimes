using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Services.ThemeParks
{

    public interface IWaltDisneyStudiosService : IThemeParkService
    {

    }

    public class WaltDisneyStudiosService : BaseThemeParkService, IWaltDisneyStudiosService
    {

        public WaltDisneyStudiosService(IWaltDisneyStudiosAdapter serviceAdapter, ITypedConfiguration typedConfiguration)
            : base(serviceAdapter, typedConfiguration)
        {
        }

        public void CurrentTimes()
        {
            //var currentTimes = _serviceAdapter.CurrentTimes();
        }
        
        public override string LocationZipCode => "77700"; // needs to be pulled from config file
    }
}