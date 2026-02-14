using Microsoft.EntityFrameworkCore;
using AppProductDb = UserCRUDAPIs.Data.DbContextProduct.AppDbContextProduct;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppProductDb>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


