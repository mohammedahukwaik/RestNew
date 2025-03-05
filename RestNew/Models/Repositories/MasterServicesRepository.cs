
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterServicesRepository : IRepository<MasterServices>
    {
        public AppDbContext db { get; }
        public MasterServicesRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterServices.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterServices entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterServices.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterServices entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterServices.Update(data);
            db.SaveChanges();
        }

        public MasterServices Find(int Id)
        {
            return db.MasterServices.SingleOrDefault(x => x.MasterServicesId == Id);
        }

        public void Update(int Id, MasterServices entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public List<MasterServices> View()
        {
            return db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterServices> ViewClient()
        {
            return db.MasterServices.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
