using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public EfAdminDal(AgricultureContext context) : base(context)
        {
        }
    }
}
