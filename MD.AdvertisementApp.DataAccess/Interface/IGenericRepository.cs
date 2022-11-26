using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.DataAccess.Interface
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
    }
}
