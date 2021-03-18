using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNET.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Display order must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
