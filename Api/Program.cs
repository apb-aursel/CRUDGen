using CRUDGen.Models;
using CRUDGen.Profiles;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbCtx>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ARQDemo_InetumProfile));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    ILoggerFactory loggerFactory = new LoggerFactory();
    ILogger logger = loggerFactory.CreateLogger<Program>();
    logger.LogInformation("migrating");
    var db = scope.ServiceProvider.GetRequiredService<DbCtx>();
    db.Database.Migrate();
    logger.LogInformation("migrated");
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
static Task HealthCheckResponseWriter(HttpContext context, HealthReport result)
{
    context.Response.ContentType = "application/json";
    var config = context.RequestServices.GetService<IConfiguration>();
    var res1 = true;
    var res2 = true;
    var conStr = config.GetConnectionString("DB");
    var conStr2 = conStr.Replace("Database=DEMO;", "Database=master;");
    using (var con = new SqlConnection(conStr))
    {
        try
        {
            con.Open();
        }
        catch
        {
            res1 = false;
        }
    }
    using (var con2 = new SqlConnection(conStr2))
    {
        try
        {
            con2.Open();
        }
        catch
        {
            res2 = false;
        }
    }
    return context.Response.WriteAsync("{ result: \"ok\", db: \"" + res1.ToString() + "\", master: \"" + res2.ToString() + "\", con1:\"" + conStr + "\", con2:\"" + conStr2 + "\" }");
}

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready"),
    ResponseWriter = HealthCheckResponseWriter
});

app.MapHealthChecks("/health/live", new HealthCheckOptions { ResponseWriter = HealthCheckResponseWriter });

app.Run();
