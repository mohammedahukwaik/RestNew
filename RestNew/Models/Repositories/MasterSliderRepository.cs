
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        public AppDbContext db { get; }
        public MasterSliderRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterSliders.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterSliders.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.MasterSliders.Update(data);
            db.SaveChanges();
        }

        public MasterSlider Find(int Id)
        {
            return db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == Id);
        }

        public void Update(int Id, MasterSlider entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSlider> View()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
