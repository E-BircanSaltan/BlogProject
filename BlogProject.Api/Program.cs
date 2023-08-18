using BlogProject.Api.Middleware;
using BlogProject.Business.Abstract;
using BlogProject.Business.Concrete;
using BlogProject.DAL.Abstract.DataManagent;
using BlogProject.DAL.Concrete.EntityFramework.Context;
using BlogProject.DAL.Concrete.EntityFramework.DataManagement;
using BlogProject.Helper.Globals;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<BlogProjectContext>();
builder.Services.AddScoped<IUnitOfWork,EfUnitOfWork>(); 
builder.Services.AddScoped<IUserServise, UserManager>();
builder.Services.AddScoped<ICategoryServise, CategoryManager>();
builder.Services.AddScoped<IArticleServise, ArticleManager>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));

var app = builder.Build();

app.UseApiAuthorizationMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiAuthorizationMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
