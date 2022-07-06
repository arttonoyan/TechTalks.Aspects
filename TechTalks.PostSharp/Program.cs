using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechTalks.DemoData;
using TechTalks.PostSharp;

var provider = Configure();
var service = provider.GetRequiredService<UniversityService>();

const string universityName = "A4";
try
{
    await service.CreateUniversityAsync(universityName);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

var dbContext = provider.GetRequiredService<UniversityDbContext>();
var uni = await dbContext.Universities.FirstOrDefaultAsync(p => p.Name == universityName);

if (uni != null)
    Console.WriteLine(uni.Name);

Console.ReadLine();

static IServiceProvider Configure()
{
    var services = new ServiceCollection();
    services
        .AddScoped<UniversityService>()
        .AddDbContext<UniversityDbContext>(cfg => cfg.UseSqlServer(Settings.ConnectionString));
    return services.BuildServiceProvider();
}

public static class Settings
{
    public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversityDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
}
