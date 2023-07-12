using TechTalks.DemoData;
using TechTalks.PostSharp.Aspects;

namespace TechTalks.PostSharp;

public class UniversityService
{
    private readonly UniversityDbContext _dbContext;

    public UniversityService(UniversityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [Transaction]
    public async Task CreateUniversityAsync(string universityName)
    {
        var university = new University { Name = universityName };
        var entity = _dbContext.Universities.Add(university);
        var count = await _dbContext.SaveChangesAsync();

        //throw new Exception("Test Throw");

        //var student = new Student { Name = "H1", Surname = "H1yan", Age = 20 };
        //student.University = university;
        //_dbContext.Add(student);
        //await _dbContext.SaveChangesAsync();

    }
}
