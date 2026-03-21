using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppMovieCase.Application.Interfaces;
using AppMovieCase.Domain.Entities;
using AppMoviesCase.Application.Interfaces.Service;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Infrastructure.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _app;

        public CategoryService(ICategoryRepository app)
        {
            _app = app;
        }

        public async Task AddCategory(Category category)
        {
            await _app.AddCategory(category);
        }

        public async Task EditCategory(Category category, int id)
        {
            await _app.EditCategory(category, id);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories =  await _app.GetAllCategory();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _app.GetCategoryById(id);
            return category;
        }

        public async Task RemoveCategory(int id)
        {
            await _app.RemoveCategory(id);
        }
    }
}