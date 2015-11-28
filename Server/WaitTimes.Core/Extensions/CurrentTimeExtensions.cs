using System.Runtime.InteropServices;

namespace WaitTimes.Core.Extensions
{
    public static class CurrentTimeExtensions
    {

        public static bool IsOpened(this string rideStatus)
        {
            if(string.IsNullOrEmpty(rideStatus)) { return false; }
            if (rideStatus.ToLower().Equals("closed")) { return false; }

            return true;            
        }

        public static int TimeInMinutes(this string rideStatus)
        {
            if (!rideStatus.IsOpened()) { return 0; }
            if (rideStatus == "0") { return 0; }

            var rawValue = rideStatus.Replace(" minutes", "");

            int outputValue;
            int.TryParse(rawValue, out outputValue);

            return outputValue;
        }
    }
}
