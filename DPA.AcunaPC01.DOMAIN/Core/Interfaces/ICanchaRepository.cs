using DPA.AcunaPC01.DOMAIN.Core.Entities;

namespace DPA.AcunaPC01.DOMAIN.Core.Interfaces
{
    internal interface ICanchaRepository
    {
        Task<int> AddCategory(Canchas canchas);
        Task<bool> DeleteCategory(int id);
        Task<IEnumerable<Canchas>> GetAllCategories();
        Task<Canchas> GetCategoryById(int id);
        Task<bool> UpdateCategory(Canchas canchas);
    }
}