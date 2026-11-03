using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Delete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public List<Admin> GetDefaults(Expression<Func<Admin, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListAll()
        {
           return _adminDal.GetListAll();
        }

        public void Insert(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void Update(Admin t)
        {
            _adminDal.Update(t);
        }
    }
}
