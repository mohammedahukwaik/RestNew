
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public AppDbContext db { get; }
        public MasterCategoryMenuRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterCategoryMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            entity.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            return db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }
        // Admin
        public List<MasterCategoryMenu> View()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false).ToList();
        }
        // Client
        public List<MasterCategoryMenu> ViewClient()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
