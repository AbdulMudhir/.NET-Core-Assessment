using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_Core_Assessment.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public string Grade { get; set; }
    }
}
