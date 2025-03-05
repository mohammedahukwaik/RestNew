
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public AppDbContext db { get; }
        public TransactionContactUsRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            
        }

        public void Add(TransactionContactUs entity)
        {
            entity.CreateDate = DateTime.Now;
            db.TransactionContactUs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            
        }

        public TransactionContactUs Find(int Id)
        {
            return null;
        }

        public void Update(int Id, TransactionContactUs entity)
        {
            
        }

        public List<TransactionContactUs> View()
        {
            return db.TransactionContactUs.ToList();
        }

        public List<TransactionContactUs> ViewClient()
        {
            return null;
        }
    }
}
