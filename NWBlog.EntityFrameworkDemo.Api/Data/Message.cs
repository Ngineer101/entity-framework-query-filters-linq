using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWBlog.EntityFrameworkDemo.Api.Data
{
    [Table(nameof(Message))]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string SentByUsername { get; set; }
    }
}
