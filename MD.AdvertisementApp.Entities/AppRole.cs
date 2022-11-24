using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Entities
{
    public class AppRole : BaseEntity
    {
        public string Definiton { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
