using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Repository;

namespace recipebookserver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;
        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        public WeatherForecastController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repoWrapper = repositoryWrapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is an info message");
            //this._repoWrapper.User

            var recipes = _repoWrapper.Recipe.FindAll();
            var users = _repoWrapper.User.FindAll();
            return new string[] { String.Join(',', recipes.Where(r => r.UserId == 1).Select(r => r.Title)), users.Count().ToString()};
        }
    }
}
