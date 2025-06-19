using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; }
        [Required]
        [Range(1, 1000)]
        public int DisplayOrder { get; set; }
         
    }
}