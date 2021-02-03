using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkRegistration.Models
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserBusinessAreas> UserBusinessAreas { get; set; }
        public DbSet<UserContactInfo> UserContactInfo { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}