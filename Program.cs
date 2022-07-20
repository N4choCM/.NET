//1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);


//2. Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


//Add Service of JWT Autorization
//TODO:
//builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//Add Custom Services (folder services)
builder.Services.AddScoped<IStudentsServices, StudentsServices>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<IChaptersServices, ChaptersServices>();
builder.Services.AddScoped<ICursoesServices, CursoesServices>();
builder.Services.AddScoped<IUsersServices, UsersServices>();

//TODO: Add rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//TODO: Config Swagger to take JWT Autorization into account
builder.Services.AddSwaggerGen();

//CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

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

//Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
