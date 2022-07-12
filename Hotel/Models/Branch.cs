using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string location { get; set; }
        [JsonIgnore]
        public virtual List<Room>? Rooms { get; set; }
        [JsonIgnore]
        public virtual List<Booking>? Bookings { get; set; }

    }
}
