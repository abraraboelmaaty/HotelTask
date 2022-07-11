using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string phone { get;set; }
        public string Email { get; set; }
        public string password { get; set; }
        [JsonIgnore]
        public List<Booking>? Bokings { get; set; }


    }
}
