
using Microsoft.EntityFrameworkCore;
using RestNew.Data;
using System.Linq;

namespace RestNew.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext db { get; }
        public MasterItemMenuRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now; 
            db.MasterItemMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterItemMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterItemMenus.Update(data);
            db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            return db.MasterItemMenus.Include(x=>x.MasterCategoryMenu).SingleOrDefault(x => x.MasterItemMenuId == Id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return db.MasterItemMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
