using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface ICategoryRepository
    {
        List<CategoryModel> getCategories();
    }
}
