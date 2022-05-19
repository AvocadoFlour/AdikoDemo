using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Data
{
    [Table("Message")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime SentTime { get; set; }
        public string Receiver { get; set; }
        public int PhoneNumber { get; set; }
        public string FileName { get; set; }

    }
}
