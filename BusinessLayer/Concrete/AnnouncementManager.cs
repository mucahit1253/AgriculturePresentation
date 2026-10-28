using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcement;
        public AnnouncementManager(IAnnouncementDal announcement)
        {
            _announcement = announcement;
        }

        public void AnnouncementStatusToFalse(int id)
        {
            _announcement.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _announcement.AnnouncementStatusToTrue(id);
        }

        public void Delete(Announcement t)
        {
            _announcement.Delete(t);
        }

        public Announcement GetById(int id)
        {
           return _announcement.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
            return _announcement.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcement.Insert(t);
        }

        public void Update(Announcement t)
        {
            _announcement.Update(t);
        }
    }
}
