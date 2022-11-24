using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Entities
{
    public class AppUserRole
    {
        public int AppUserId { get; set; }
        public AppUser appUser{ get; set; }

        //---------------------------------------------------------------------
        public int AppRoleId { get; set; }
        public AppRole  appUserRole { get; set; }
    }
}
