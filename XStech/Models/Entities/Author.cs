using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XStech.Models
{
    public class Author
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        [MaxLength(100)]
        public string ProfilePicture { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}