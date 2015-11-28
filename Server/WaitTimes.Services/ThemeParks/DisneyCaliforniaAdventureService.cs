using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Services.ThemeParks
{
    public interface ICaliforniaAdventureService : IThemeParkService
    {

    }

    public class CaliforniaThemeParkService : BaseThemeParkService, ICaliforniaAdventureService
    {

        public CaliforniaThemeParkService(ICaliforniaAdventureAdapter serviceAdapter, ITypedConfiguration typedConfiguration) : base(serviceAdapter, typedConfiguration)
        {
        }

        public void CurrentTimes()
        {
            //var currentTimes = _serviceAdapter.CurrentTimes();
        }
        

        public override string LocationZipCode => "92802"; // needs to be pulled from config file
    }
}