using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WellBellSecure.Models
{
    public class Location {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public object postcode { get; set; }
    }

    public class Picture {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string gender { get; set; }
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        //public Location location { get; set; }
 
        public int registered { get; set; }
        public int dob { get; set; }
 
        public string cell { get; set; }
 
      //  public Picture picture { get; set; }
        public string nat { get; set; }
    }
}
