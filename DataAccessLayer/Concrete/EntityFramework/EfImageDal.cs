using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfImageDal : GenericRepository<Image>, IImageDal
    {
        public EfImageDal(AgricultureContext context) : base(context)
        {
        }
    }
}
