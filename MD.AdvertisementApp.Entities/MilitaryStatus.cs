using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Entities
{
    public class MilitaryStatus:BaseEntity
    {
        public string Definition { get; set; }
        public List <AdvertisementAppUser> AdvertisementAppUser { get; set; }
    }
}
