using APIFun.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add cross origin resource sharing
builder.Services.AddCors();

// build service for sqlite
builder.Services.AddDbContext<FoodContext>(options =>
options.UseSqlite(builder.Configuration["ConnectionStrings:FoodConnection"])
);

// get generic IFoodRepository, make EF for everyone on server with specific data
builder.Services.AddScoped<IFoodRepository, EFFoodRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
;

// use app with port open for vs code
app.UseCors(p => p.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
