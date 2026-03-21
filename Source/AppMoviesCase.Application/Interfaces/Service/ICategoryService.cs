using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMoviesCase.Domain.Entities;

namespace AppMoviesCase.Application.Interfaces.Service
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(int id);
        public Task AddCategory(Category movie);
        public Task EditCategory(Category movie, int id);
        public Task RemoveCategory(int id);
    }
}