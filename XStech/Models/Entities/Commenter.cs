using System.ComponentModel.DataAnnotations;

namespace XStech.Models
{
    public class Commenter
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Author? Author { get; set; }
    }
}
