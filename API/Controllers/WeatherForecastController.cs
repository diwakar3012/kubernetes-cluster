using EGDaySchedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Xml.Linq;

namespace DemoK8sAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly string SecretsPath =  "/mnt/secrets-store";
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("DoGetCurrentDate")]
        //[Authorize]
        public async Task<string> DoGetCurrentDate()
        {
            return DateTime.Now.ToString("dd-MMM-yyyy");
        }

        [HttpGet]
        [Route("DoGetUserData")]
        //[Authorize]
        public async Task<APIResponseData> DoGetUsersDataFromMongoDB()
        {
            APIResponseData obj = new APIResponseData();
            var Db = DBContext.MongoDBConnection(_configuration);
            var UsersCollection = Db.GetCollection<Users>("Users");
            var filter1 = Builders<Users>.Filter.Empty;
            var users_data =await UsersCollection.Find(filter1).ToListAsync();
            obj.data = users_data;
            obj.responseTime = DateTime.Now;

            obj.status = "Success-200 " + Environment.GetEnvironmentVariable("DB_PASSWORD");
            return obj;
        }

        [HttpGet]
        [Route("DoGetSecretFromKeyVault")]
        //[Authorize]
        public IActionResult DoGetSecretFromKeyVault()
        {
            string secretName = "dbname";
            string secretFilePath = Path.Combine(SecretsPath, secretName);

            if (!System.IO.File.Exists(secretFilePath))
            {
                return NotFound($"Secret DbName not found.");
            }

            string secretValue = System.IO.File.ReadAllText(secretFilePath);
            return Ok(new { SecretName = secretName, SecretValue = secretValue });
        }
    }
}