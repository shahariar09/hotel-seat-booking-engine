using hotel_seat_booking_engine.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QueryModelMapper.Model;

namespace hotel_seat_booking_engine.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public WeatherForecastController(ApplicationDbContext dbContext, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("SaveLayout")]
        public async Task<IActionResult> Post(List<Layout> layout)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {

               
                _dbContext.Layout.AddRange(layout);
                _dbContext.SaveChanges();
                return Ok();
            }
     
        }

        [HttpPost]
        [Route("UpdateLayout")]
        public async Task<IActionResult> Update(List<int> seatNoList)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {


                var existingSeatList = await _dbContext.Layout.Where(c=> seatNoList.Contains((int)c.Id)).ToListAsync();
                if (existingSeatList != null)
                {
                    foreach (var item in existingSeatList)
                    {
                        item.OrderStatus = true;
                    }
                }
                _dbContext.SaveChanges();
                return Ok();
            }

        }

        [HttpGet]
        [Route("GetLayout")]
        public async Task<IActionResult> Get(string layoutName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {


                var data = await _dbContext.Layout.Where(c=>c.Name== layoutName).ToListAsync();
                return Ok(data);
            }

        }
        [HttpGet]
        [Route("RemoveLayout")]
        public async Task<IActionResult> Delete(string layoutName)
        {
            var data = await _dbContext.Layout.Where(c=>c.Name==layoutName).ToListAsync();
            _dbContext.RemoveRange(data);
            _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("RemoveTest")]
        public async Task<IActionResult> TestDelete(string deleteById)
        {         
            return Ok();
        }

    }
}