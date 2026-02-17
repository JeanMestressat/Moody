using Microsoft.EntityFrameworkCore;
public class ApiContext : DbContext
{
    public string DbPath { get; private set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Today> Todays { get; set; }

    public ApiContext()
    {
        DbPath = "BDD/ApiMoody.db";
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}
