using System;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategory();
    Task<Category> GetCategoryById(int id);
    Task EditCategory(Category category, int id);
    Task RemoveCategory(int id);

    Task AddCategory(Category category);
}
