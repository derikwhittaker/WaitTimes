using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaitTimes.Models.Dto;

namespace WaitTimes.Persistance.Raven
{
    public interface IWaitTimesRepository
    {
        Task<List<CurrentTimeDto>> Save(List<CurrentTimeDto> remoteHostCurrentTimes);
        CurrentTimeDto Fetch(string id);
    }

    public class WaitTimesRepository : BaseRepository, IWaitTimesRepository
    {
        public WaitTimesRepository() : base("WaitTimes")
        {
            
        }

        public async Task<List<CurrentTimeDto>> Save(List<CurrentTimeDto> remoteHostCurrentTimes)
        {
            using (var session = Store.OpenSession())
            {
                foreach (var currentTime in remoteHostCurrentTimes)
                {
                    var id = Guid.NewGuid().ToString();
                    currentTime.Id = id;
                    session.Store(currentTime, id);    
                }

                session.SaveChanges();
            }

            return remoteHostCurrentTimes;

            //            var fullEndpoint = "http://localhost:8080/databases/WaitTimes/docs";
            //            var requestUri = new Uri(fullEndpoint);
            //
            //            using (var httpClient = new HttpClient())
            //            {
            //                httpClient.BaseAddress = requestUri;
            //
            //                foreach (var currentTime in remoteHostCurrentTimes)
            //                {
            //
            //                    var asJson = JsonConvert.SerializeObject(currentTime);
            //                    var contentPost = new StringContent(asJson, Encoding.UTF8, "application/json");
            //
            //                    var postAsync = await httpClient.PostAsync(requestUri, contentPost);
            //
            //                }
            //
            //            }
        }

        public CurrentTimeDto Fetch(string id)
        {
            using (var session = Store.OpenSession("WaitTimes"))
            {

                var currentTimeDtos = session.Query<CurrentTimeDto>().FirstOrDefault(i => i.Id == id);

                return currentTimeDtos;
            }            
        }
    }
}