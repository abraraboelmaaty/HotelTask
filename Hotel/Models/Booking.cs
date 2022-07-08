using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Booking
    {
        //public int Id { get; set; }    
        public DateTime startDate { get; set; }

        public DateTime endDate { set; get; }
        [ForeignKey("Room")]
        [JsonIgnore]
        public int? RoomId { get; set; }
        [ForeignKey("Customer")]
        [JsonIgnore]
        public int? CustomerId { set; get; }
        [JsonIgnore]
        public virtual Room? Room { get; set; }
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }


    }
}
