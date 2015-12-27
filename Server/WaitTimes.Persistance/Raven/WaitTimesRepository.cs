using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;
using WaitTimes.Models.Dto;

namespace WaitTimes.Persistance.Raven
{
    public interface IWaitTimesRepository
    {
        Task<List<CurrentTimeDto>> Save(List<CurrentTimeDto> remoteHostCurrentTimes);
        CurrentTimeDto Fetch();
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

        public CurrentTimeDto Fetch()
        {
            using (IDocumentSession session = Store.OpenSession("WaitTimes"))
            {
                //session.Advanced.DocumentQuery<CurrentTimeDto>()
                var foo = session.Query<CurrentTimeDto>().FirstOrDefault();

                var currentTimeDtos =
                    session.Query<CurrentTimeDto>().Where(i => i.Id == "fc21a9dc-ae2c-4e8d-93b5-f5877d4f2d7d");
            }

            return null;
        }
    }

    public class BaseRepository
    {

        private Lazy<IDocumentStore> _store;

        public BaseRepository(string database)
        {
            Database = database;

            _store = new Lazy<IDocumentStore>(CreateStore);
        }

        public IDocumentStore Store => _store.Value;

        public string Database { get; private set; }

        private IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Url = "http://localhost:8080",
                DefaultDatabase = Database
            }.Initialize();

            return store;
        }
    }
}