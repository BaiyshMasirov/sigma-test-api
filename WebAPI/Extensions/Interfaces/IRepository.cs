using WebAPI.Extensions.Entities.Common;

namespace WebAPI.Extensions.Interfaces
{
    internal interface IRepository<T> where T : BaseEntity
    {
        void Create(T item); // create object

        void Update(T item); // update object

        Task Save();  // save changes
    }
}