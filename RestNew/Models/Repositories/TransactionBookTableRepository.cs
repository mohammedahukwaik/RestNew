
using RestNew.Data;

namespace RestNew.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public AppDbContext db { get; }
        public TransactionBookTableRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            
        }

        public void Add(TransactionBookTable entity)
        {
            //entity.IsActive = true;
            //entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            //entity.EditDate = DateTime.Now;
            db.TransactionBookTables.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            
        }

        public TransactionBookTable Find(int Id)
        {
            return null;
        }

        public void Update(int Id, TransactionBookTable entity)
        {
            
        }

        public List<TransactionBookTable> View()
        {
            return db.TransactionBookTables.ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
            return null;
        }
    }
}
