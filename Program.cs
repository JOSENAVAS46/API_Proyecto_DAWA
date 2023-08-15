using API_Proyecto_DAWA.Context;
using API_Proyecto_DAWA.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Configurar el DbContext
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Configurar CORS
//Configurar los Repository
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
          builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
        });
});

builder.Services.AddScoped<I_UsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<I_ProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<I_ClienteRepository, ClienteRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
