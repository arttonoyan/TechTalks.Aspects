using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using TechTalks.DemoData;
using TechTalks.PostSharp.Aspects;

namespace TechTalks.PostSharp.Benchmark
{
    [MemoryDiagnoser]
    public class TransactionBenchmarker
    {
        private UniversityDbContext _dbContext;

        [Params(100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _dbContext = new UniversityDbContext();
        }

        [Benchmark]
        public async Task TransactionAspect()
        {
            for (int i = 0; i < Count; i++)
            {
                try
                {
                    await AddUniversityAspectAsync(i);
                }
                catch { }
            }
        }

        [Benchmark]
        public async Task TransactionMenualy()
        {
            for (int i = 0; i < Count; i++)
            {
                try
                {
                    await AddUniversityMenualyAsync(i);
                }
                catch { }
            }
        }

        [Transaction]
        private Task AddUniversityAspectAsync(int number)
        {
            return AddUniversityAsync(number);
        }

        private async Task AddUniversityMenualyAsync(int number)
        {
            using var scope = new TransactionScope();
            await AddUniversityAsync(number);
            scope.Complete();
        }

        private async Task AddUniversityAsync(int number)
        {
            var uni = new University { Name = $"A{number}" };
            _dbContext.Universities.Add(uni);
            await _dbContext.SaveChangesAsync();

            throw new Exception();
        }
    }
}
