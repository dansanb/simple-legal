using Core;
using Microsoft.EntityFrameworkCore;

namespace DbSeeder;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=simplelegal;Username=postgres");

        using (var context = new AppDbContext(optionsBuilder.Options))
        {

        }
    }
}