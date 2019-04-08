using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Password {get; set;}

    }
}