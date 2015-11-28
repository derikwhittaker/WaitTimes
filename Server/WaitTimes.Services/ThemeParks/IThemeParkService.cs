using System.Collections.Generic;
using System.Threading.Tasks;
using WaitTimes.Models.Api;
using WaitTimes.Services.Models;

namespace WaitTimes.Services.ThemeParks
{
    public interface IThemeParkService
    {
        void CurrentTimes();
        Task<GatherResults> Gather(CurrentWeatherDto weatherResult);

        string LocationZipCode { get; }
    }
}