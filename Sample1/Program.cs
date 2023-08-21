using Sample1;
using SampleData;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repository;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudendDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDbConnectionString")));
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudnetRepository, StudnetRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddAutoMapper(typeof(AutoMappers));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
