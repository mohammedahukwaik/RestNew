
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public AppDbContext db { get; }
        public MasterOfferRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterOffers.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterOffer entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterOffers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterOffers.Update(data);
            db.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            return db.MasterOffers.SingleOrDefault(x => x.MasterOfferId == Id);
        }

        public void Update(int Id, MasterOffer entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
