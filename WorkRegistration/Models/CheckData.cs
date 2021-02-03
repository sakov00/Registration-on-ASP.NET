using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkRegistration.Models
{
    public class CheckData
    {
        public string ConfirmPassword { get; set; }
        public string ConfirmEmail { get; set; }
        public string Captcha { get; set; }
    }
}