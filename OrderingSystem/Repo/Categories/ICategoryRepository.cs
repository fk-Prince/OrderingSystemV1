using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> getCategories();
    }
}
