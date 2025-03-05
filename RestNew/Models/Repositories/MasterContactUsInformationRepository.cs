
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public AppDbContext db { get; }
        public MasterContactUsInformationRepository(AppDbContext _db)
        {
            db = _db;   
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterContactUsInformation entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Update(data);
            db.SaveChanges();
        }

        public MasterContactUsInformation Find(int Id)
        {
            return db.MasterContactUsInformations.SingleOrDefault(x => x.MasterContactUsInformationId == Id);
        }

        public void Update(int Id, MasterContactUsInformation entity)
        {
            //var data = Find(Id);
            //entity.CreateDate = data.CreateDate;
            //entity.IsActive = data.IsActive;
            //entity.IsDelete = data.IsDelete;
            entity.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Update(entity);
            db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return db.MasterContactUsInformations.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterContactUsInformation> ViewClient()
        {
            return db.MasterContactUsInformations.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
