using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace React.Entity
{
    public class Post : IEntitybase
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string PostContent { get; set; }
    }
}
