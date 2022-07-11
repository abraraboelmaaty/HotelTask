using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required,MaxLength(50)]
        public string FirstName {get;set;}
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [JsonIgnore]
        public List<Booking>? Bokings { get; set; }

    }
}
