using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WorkRegistration.Models
{
    public class UserBusinessAreas
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public bool Finance { get; set; }
        [Required]
        public bool Operations { get; set; }
        [Required]
        public bool IT { get; set; }
        [Required]
        public bool Sales { get; set; }
        [Required]
        public bool Administrative { get; set; }
        [Required]
        public bool Legal { get; set; }
        [Required]
        public bool Marketing { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}