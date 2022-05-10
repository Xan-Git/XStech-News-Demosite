using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XStech.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Post Post { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }

        [Column(TypeName = "datetime2(2)")]
        public DateTime PostedTime { get; set; }
        public Commenter Commenter { get; set; }

        public Comment? Parent { get; set; }
    }
}
