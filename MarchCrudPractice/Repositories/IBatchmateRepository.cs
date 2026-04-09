using MarchCrudPractice.Models;

namespace MarchCrudPractice.Repositories
{
    public interface IBatchmateRepository
    {
        IEnumerable<Batchmates> GetAllBatchmates();
        Batchmates GetBatchmateById(int id);
        void CreateBatchmates(Batchmates batchmate);
        void UpdateBatchmates(Batchmates batchmate);
        void DeleteBatchmates(int id);
    }
}
