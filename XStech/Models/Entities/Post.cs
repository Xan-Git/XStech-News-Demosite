using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XStech.Models
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string PartialURL { get; set; }

        [MaxLength(100)]
        public string ImageURL { get; set; }

        public Author Author { get; set; }

        [MaxLength(25)]
        public string Category { get; set; }

        public int Views { get; set; }

        [Column(TypeName = "datetime2(2)")]
        public DateTime UploadDate { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}

