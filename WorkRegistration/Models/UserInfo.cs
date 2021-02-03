using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkRegistration.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Salutation { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Title { get; set; }
    }
}