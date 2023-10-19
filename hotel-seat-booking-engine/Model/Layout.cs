using System.ComponentModel.DataAnnotations;

namespace hotel_seat_booking_engine.Model
{
    public class Layout
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? TableNo { get; set; }
        public int? ChairNo { get; set; }

        public double? TablePositionX { get; set; }
        public double? TablePositionY { get; set; }

        public double? ChairPositionX { get; set; }
        public double? ChairPositionY { get; set; }
        public bool? OrderStatus { get; set; }

    }
}
