
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext db { get; }
        public MasterSocialMediaRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSocialMedia entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterSocialMedia.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedia entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(data);
            db.SaveChanges();
        }

        public MasterSocialMedia Find(int Id)
        {
            return db.MasterSocialMedia.SingleOrDefault(x => x.MasterSocialMediaId == Id);
        }

        public void Update(int Id, MasterSocialMedia entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSocialMedia> View()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedia> ViewClient()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
