using WaitTimes.Core.Configuration;
using WaitTimes.Gatherers.Adapters;

namespace WaitTimes.Services.ThemeParks
{
    public interface IMagicKingdomService : IThemeParkService
    {

    } 

    public class MagicKingdomService : BaseThemeParkService, IMagicKingdomService
    {

        public MagicKingdomService(IMagicKingdomAdapter serviceAdapter, ITypedConfiguration typedConfiguration)
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