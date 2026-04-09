using MarchCrudPractice.Data;
using MarchCrudPractice.Models;

namespace MarchCrudPractice.Repositories
{
    public class BatchmateRepository : IBatchmateRepository
    {
        private readonly BatchmateDbContext Context;
        public BatchmateRepository(BatchmateDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Batchmates> GetAllBatchmates()
        {
            return Context.Batchmate.ToList();
        }

        public Batchmates GetBatchmateById(int id)
        {
            var batcgmates = Context.Batchmate.FirstOrDefault(x => x.Id == id);
            if(batcgmates == null)
            {
                throw new Exception("Batchmate not found");
            }
            return batcgmates;
        }
        public void CreateBatchmates(Batchmates batchmate)
        {
            Context.Batchmate.Add(batchmate);
            Context.SaveChanges();
        }

        public void UpdateBatchmates(Batchmates batchmate)
        {
            Context.Batchmate.Update(batchmate);
            Context.SaveChanges();
        }
        public void DeleteBatchmates(int id)
        {
            var batchmate = Context.Batchmate.FirstOrDefault(x => x.Id == id);
            if(batchmate != null)
            {
                Context.Batchmate.Remove(batchmate);
                Context.SaveChanges();
            }
        }
    }
}
