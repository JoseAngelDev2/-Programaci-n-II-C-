using Microsoft.EntityFrameworkCore;
using AppProductDb = UserCRUDAPIs.Data.DbContextProduct.AppDbContextProduct;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppProductDb>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();


