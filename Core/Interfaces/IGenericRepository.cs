using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity //T moze da bude bilo koji tip
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();

         Task<T> GetEntityWithSpec(ISpecification<T> spec);

         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}