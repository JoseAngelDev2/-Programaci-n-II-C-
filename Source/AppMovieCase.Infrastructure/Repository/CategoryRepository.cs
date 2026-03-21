using System;
using AppMovieCase.Application.Interfaces;
using AppMoviesCase.Domain.Entities;
using AppMoviesCase.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using AppCategoryDb = AppMovieCase.Infrastructure.Data.AppMovieDbContext;
namespace AppMovieCase.Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{

    private readonly AppCategoryDb _app;

    public CategoryRepository(AppCategoryDb app)
    {
        _app = app;
    }

    public async Task AddCategory(Category category)
    {
        var Newcategory = new CategoryModel
        {
            
            Name = category.Name,
            created_at = category.created_at,
            update_at = category.update_at
        };

        await _app.Categories.AddAsync(Newcategory);
    }
    public async Task EditCategory(Category Updatecategory, int id)
    {
        var categoryDB = await _app.Categories.FindAsync(id);

        if (categoryDB is null)
        {
            return;
        }
        categoryDB.Name =  Updatecategory.Name == null ? categoryDB.Name : Updatecategory.Name;
        await SAVE();
    }

    public async Task<IEnumerable<Category>> GetAllCategory()
    {
        var category = await _app.Categories.Include(m => m.Movies).AsNoTracking().ToListAsync();

        return category.Select(c => new Category
        {
            Name = c.Name
        });
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _app.Categories.FindAsync(id);

        if (category is null) { return null!; }

        var result = new Category
        {
            Name = category.Name
        };
    
        return result;
    }

    public async Task RemoveCategory(int id)
    {
        var category = await _app.Categories.FindAsync(id);
        
        if (category is null) { return; }

        _app.Remove(category);

        await SAVE();
    }


    public async Task SAVE()
    {
        await _app.SaveChangesAsync();
    }
}
