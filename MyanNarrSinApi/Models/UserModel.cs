using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyanNarrSinApi.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }

        public UserModel()
        {
            Type = "free";
            Role = "user";
        }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string User_Name { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Location { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Role { get; set; }
    }
}
