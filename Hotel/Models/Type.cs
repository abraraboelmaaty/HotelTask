using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Room>? Rooms { get; set; }   
    }
}
