//1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityApiBackend;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;
// Add Serilog usings
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Config Serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf
        .WriteTo.Console()
        .WriteTo.Debug()
        .ReadFrom.Configuration(hostBuilderCtx.Configuration);
});


//2. Connection with SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add context
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


//Add Service of JWT Autorization
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//Add Custom Services (folder services)
builder.Services.AddScoped<IStudentsServices, StudentsServices>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<IChaptersServices, ChaptersServices>();
builder.Services.AddScoped<ICursoesServices, CursoesServices>();
builder.Services.AddScoped<IUsersServices, UsersServices>();

//TODO: Add rest of services

//AddAuthorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Config Swagger to take JWT Autorization into account
builder.Services.AddSwaggerGen(options =>
{
    //We define the security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
        }
    });

}
    );

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

//Tell app to use serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
