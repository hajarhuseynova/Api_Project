
using ApiIntro.Core.Repositories;
using ApiIntro.Data.Context;
using ApiIntro.Data.Repositories.Implementations;
using ApiIntro.Profiles.Categories;
using ApiIntro.Service.Services.Implementations;
using ApiIntro.Service.Services.Interfaces;
using ApiIntro.Validations.Categories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers()?.AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ProductPostDtoValidation>());


builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<ApiIntroDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
