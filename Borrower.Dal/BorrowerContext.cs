using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Borrower.Dal
{
    public class BorrowerContext
    {
        private readonly IMongoDatabase _database;

        public BorrowerContext(IOptions<BorrowerDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}