﻿
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        public AppDbContext db { get; }
        public SystemSettingRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.SystemSettings.Update(data);
            db.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.SystemSettings.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.SystemSettings.Update(data);
            db.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            return db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            entity.EditDate = DateTime.Now;
            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
