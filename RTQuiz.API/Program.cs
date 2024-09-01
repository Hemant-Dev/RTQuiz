using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using RTQuiz.Data;
using RTQuiz.IRepositories;
using RTQuiz.IServices;
using RTQuiz.Profiles;
using RTQuiz.Repositories;
using RTQuiz.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
// Add services to the container.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<QuizDBContext>(options => options.UseNpgsql(connectionString));

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    });

builder.Services.AddAutoMapper(typeof(QuizProfile));
builder.Services.AddAutoMapper(typeof(QuestionProfile));
builder.Services.AddAutoMapper(typeof(QuizSeriesProfile));
builder.Services.AddAutoMapper(typeof(AnswerProfile));

builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IQuizSeriesRepository, QuizSeriesRepository>();
builder.Services.AddScoped<IQuizSeriesService, QuizSeriesService>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IAnswerService, AnswerService>();    

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
