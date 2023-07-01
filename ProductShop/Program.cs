using Microsoft.EntityFrameworkCore;
using ProductShop.DBContext;
using ProductShop.Interface;
using ProductShop.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("ProductConnection");
builder.Services.AddDbContext<ProductContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("ProductConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddHostedService<Worker>();

builder.Services.AddTransient<IProduct, ProductServic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
