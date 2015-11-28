using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WaitTimes.Models.Dto;

namespace WaitTimes.Persistance.Raven
{
    public interface IWaitTimesRepository
    {
        Task Save(List<CurrentTimeDto> remoteHostCurrentTimes);

    }

    public class WaitTimesRepository : IWaitTimesRepository
    {

        public async Task Save(List<CurrentTimeDto> remoteHostCurrentTimes)
        {
            var fullEndpoint = "http://localhost:8080/databases/WaitTimes/docs";
            var requestUri = new Uri(fullEndpoint);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = requestUri;

                foreach (var currentTime in remoteHostCurrentTimes)
                {

                    var asJson = JsonConvert.SerializeObject(currentTime);
                    var contentPost = new StringContent(asJson, Encoding.UTF8, "application/json");

                    var postAsync = await httpClient.PostAsync(requestUri, contentPost);

                }

            }
        }
    }
}