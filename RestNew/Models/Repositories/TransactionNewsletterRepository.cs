
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public AppDbContext db { get; }
        public TransactionNewsletterRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            
        }

        public void Add(TransactionNewsletter entity)
        {
            entity.CreateDate = DateTime.Now;
            db.TransactionNewsletters.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            
        }

        public TransactionNewsletter Find(int Id)
        {
            return null;
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
            
        }

        public List<TransactionNewsletter> View()
        {
            return db.TransactionNewsletters.ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            return null;
        }
    }
}
