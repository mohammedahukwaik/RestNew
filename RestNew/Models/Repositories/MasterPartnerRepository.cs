
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public AppDbContext db { get; }
        public MasterPartnerRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterPartners.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterPartners.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterPartners.Update(data);
            db.SaveChanges();
        }

        public MasterPartner Find(int Id)
        {
            return db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);
        }

        public void Update(int Id, MasterPartner entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterPartners.Update(entity);
            db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
