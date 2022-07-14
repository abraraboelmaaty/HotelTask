using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Room
    {
        public Room()
        {
            Bokings = new List<Booking>();
        }
        //[Index(IsUnique = true)]
        //[StringLength(12)]
        public int Id { get; set; }

        public string Description { get; set; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        //public bool Avilable { get; set; } 
        public RoomStatus Status { get; set; }
        public int CoustomerCount { get; set; }
        public bool CanBookingmore { get; set; }
        [ForeignKey("Branch")]
       
        public virtual int BranchId { get; set; }
       
        [JsonIgnore]
        public virtual List<Booking>? Bokings {get;set;}
        [JsonIgnore]
        public virtual Branch? Branch { get; set; }
        
    }
}
