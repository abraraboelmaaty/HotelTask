using Hotel.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public bool Avilable { get; set; }  
        [ForeignKey("Branch")]
       
        public virtual int BranchId { get; set; }
        //[ForeignKey("Type")]
        //[JsonIgnore]
        //public int? TypeId { get; set; }
        //[JsonIgnore]
        //public virtual RoomType? Type { get; set; }
        [JsonIgnore]
        public virtual List<Booking>? Bokings {get;set;}
        [JsonIgnore]
        public virtual Branch? Branch { get; set; }
        
    }
}
