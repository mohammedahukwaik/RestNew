
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext db { get; }
        public MasterMenuRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterMenus.Update(data);
            db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
