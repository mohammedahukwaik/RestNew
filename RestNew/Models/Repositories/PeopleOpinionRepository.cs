
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class PeopleOpinionRepository : IRepository<PeopleOpinion>
    {
        public AppDbContext db { get; }
        public PeopleOpinionRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.PeopleOpinion.Update(data);
            db.SaveChanges();
        }

        public void Add(PeopleOpinion entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id, PeopleOpinion entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.PeopleOpinion.Update(data);
            db.SaveChanges();
        }

        public PeopleOpinion Find(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, PeopleOpinion entity)
        {
            throw new NotImplementedException();
        }

        public List<PeopleOpinion> View()
        {
            return db.PeopleOpinion.Where(x => x.IsDelete == false).ToList();
        }

        public List<PeopleOpinion> ViewClient()
        {
            return db.PeopleOpinion.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
