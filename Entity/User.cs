using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace React.Entity
{
    public class User : IEntitybase
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name {get; set;}
        [Required]
        public string Email {get; set;}
        [NotMapped]
        public string Password {get; set;}

    }
}