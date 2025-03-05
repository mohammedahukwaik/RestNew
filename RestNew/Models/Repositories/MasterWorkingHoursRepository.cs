
using Microsoft.AspNetCore.Identity;
using RestNew.Data;
using System.Security.Claims;

namespace RestNew.Models.Repositories
{
    public class MasterWorkingHoursRepository : IRepository<MasterWorkingHours>
    {
        public AppDbContext db { get; }
        public MasterWorkingHoursRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterWorkingHours.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterWorkingHours entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterWorkingHours.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHours entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterWorkingHours.Update(data);
            db.SaveChanges();
        }

        public MasterWorkingHours Find(int Id)
        {
            return db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHoursId == Id);
        }

        public void Update(int Id, MasterWorkingHours entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public List<MasterWorkingHours> View()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHours> ViewClient()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
