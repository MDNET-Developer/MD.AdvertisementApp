using MD.AdvertisementApp.DataAccess.Contexts;
using MD.AdvertisementApp.DataAccess.Interface;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.DataAccess.Repositories
{
    public class GenericRepository<T> where T:BaseEntity,IGenericRepository<T>
    {
        public readonly AdvertisementContext _advertisementContext;

        public GenericRepository(AdvertisementContext advertisementContext)
        {
            _advertisementContext = advertisementContext;
        }
    }
}
