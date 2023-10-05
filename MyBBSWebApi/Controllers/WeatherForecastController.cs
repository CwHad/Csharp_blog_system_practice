using Microsoft.AspNetCore.Mvc;
using MyBBSWebApi.DAL.Factorys;
using MyBBSWebApi.Models.Models;

namespace MyBBSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        // Get/Post/Put/Delete
        // Get => 数据的获取
        // Post => 数据的插入
        // Put => 数据更新
        // Delete => 数据的删除
        public IEnumerable<Post> Get()
        {
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = Random.Shared.Next(-20, 55),
            //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            // })
            // .ToArray();

            // using var context = new MySecondDbContext();
            // var res = context.Posts.ToList();
            // return res;

            var context = DbContextFactory.GetDbContext();
            return context.Posts.ToList();
        }
    }
}