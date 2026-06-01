using BookstoreApplication;
using BookstoreApplication.Data;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - definicija politike
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AwardService>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<PublisherRepository>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<AwardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");        

app.UseAuthorization();

app.MapControllers();

app.Run();