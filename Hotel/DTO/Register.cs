using System.ComponentModel.DataAnnotations;

namespace Hotel.DTO
{
    public class Register
    {
        [Required, StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
