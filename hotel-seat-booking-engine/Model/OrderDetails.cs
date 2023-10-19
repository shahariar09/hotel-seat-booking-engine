using System.ComponentModel.DataAnnotations;

namespace hotel_seat_booking_engine.Model
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string LayoutName { get; set; }
        public int SeatNo { get; set; }
    }
}
