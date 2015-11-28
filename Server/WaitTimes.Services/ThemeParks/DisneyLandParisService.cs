using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters.ThemePark;

namespace WaitTimes.Services.ThemeParks
{
    public interface IDisneyLandParisService : IThemeParkService
    {

    }

    public class DisneyLandParisService : BaseThemeParkService, IDisneyLandParisService
    {

        public DisneyLandParisService(IDisneyLandParisAdapter serviceAdapter,  ITypedConfiguration typedConfiguration)
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