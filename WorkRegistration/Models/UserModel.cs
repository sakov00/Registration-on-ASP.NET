using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkRegistration.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Info = new UserInfo();
            Contact = new UserContactInfo();
            Areas = new UserBusinessAreas();
            Address = new UserAddress();
        }
        public UserInfo Info { get; set; }
        public UserContactInfo Contact { get; set; }
        public UserBusinessAreas Areas { get; set; }
        public UserAddress Address { get; set; }
    }
}