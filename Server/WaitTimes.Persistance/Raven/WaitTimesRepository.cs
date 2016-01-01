using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Linq;
using WaitTimes.Models.Dto;

namespace WaitTimes.Persistance.Raven
{
    public interface IWaitTimesRepository
    {
        List<CurrentTimeDto> Save(List<CurrentTimeDto> remoteHostCurrentTimes);
        CurrentTimeDto Fetch(string id);

        void FixBadData();
    }

    public class WaitTimesRepository : BaseRepository, IWaitTimesRepository
    {
        public WaitTimesRepository() : base("WaitTimes")
        {
            
        }

        public List<CurrentTimeDto> Save(List<CurrentTimeDto> remoteHostCurrentTimes)
        {
            using (var session = Store.OpenSession())
            {
                foreach (var currentTime in remoteHostCurrentTimes)
                {
                    var id =  currentTime.Id;
                    if (string.IsNullOrEmpty(currentTime.Id))
                    {
                        id = Guid.NewGuid().ToString();
                        currentTime.Id = id;
                        session.Store(currentTime, id);
                    }

                    session.Store(currentTime);
                }

                session.SaveChanges();
            }

            return remoteHostCurrentTimes;
            
        }

        public void FixBadData()
        {
            using (var session = Store.OpenSession())
            {
                var foundItemsQuery = session.Query<CurrentTimeDto>("IndexByRideName");
                var foundItems = session.Advanced.Stream<CurrentTimeDto>(foundItemsQuery);

                while (foundItems.MoveNext())
                {
                    var document = foundItems.Current.Document;

                    if (document.RideName.Contains("\"") || document.RideName.Contains("«") ||
                        document.RideName.Contains("»"))
                    {
                        document.RideName = document.RideName.Replace("\"", "").Replace("«", "").Replace("»", "").Trim();

                        Save(new List<CurrentTimeDto>() {document});
                    }
                    
                }

            }
        } 

        public CurrentTimeDto Fetch(string id)
        {
            using (var session = Store.OpenSession(Database))
            {

                var currentTimeDtos = session.Load<CurrentTimeDto>(id);

                return currentTimeDtos;
            }            
        }
    }
}