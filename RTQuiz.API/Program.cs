using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<QuizDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();


// Api Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("X-Api-Version"));   
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v''V'";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();  

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
