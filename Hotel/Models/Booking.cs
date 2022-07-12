using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime startDate { get; set; }

        public DateTime endDate { set; get; }
        [ForeignKey("Room")] 
        public int RoomId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { set; get; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        [JsonIgnore]
        public virtual Room? Room { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        [JsonIgnore]
        public virtual Branch? Branch { get; set; }


    }
}
