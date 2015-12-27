using System;
using Raven.Client;
using Raven.Client.Document;

namespace WaitTimes.Persistance.Raven
{
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