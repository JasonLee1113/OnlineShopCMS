using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShopCMS.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public int? Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
