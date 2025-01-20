using MongoDB.Driver;

namespace EGDaySchedule.Models
{
    public class DBContext
    {
        public static IMongoDatabase MongoDBConnection(IConfiguration _configuration)
        {
            //var client = new MongoClient(_configuration["ConnectionString"]);
            const string connectionUri = "mongodb+srv://diwakar302002:phEAVnrQLUZlEnb8@cluster0.eqymywc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            var client = new MongoClient(settings);
            var Db = client.GetDatabase(_configuration["DatabaseName"]);
            return Db;
        }
    }
}
