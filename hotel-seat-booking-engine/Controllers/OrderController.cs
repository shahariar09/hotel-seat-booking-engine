using hotel_seat_booking_engine.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryModelMapper.Model;

namespace hotel_seat_booking_engine.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderController(ApplicationDbContext dbContext)
        { 

            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<int> layout)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {


                //_dbContext.Layout.AddRange(layout);
                _dbContext.SaveChanges();
                return Ok();
            }

        }
    }
}
