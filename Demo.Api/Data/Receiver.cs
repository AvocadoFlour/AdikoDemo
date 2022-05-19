using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Api.Data
{
    [Table("Receiver")]
    public class Receiver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string NameSurname { get; set; }
        public int Number { get; set; }

    }
}
