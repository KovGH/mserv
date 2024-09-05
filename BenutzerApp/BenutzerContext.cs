using Microsoft.EntityFrameworkCore;

namespace Seminar;

public class BenutzerContext : DbContext
{
    public BenutzerContext(DbContextOptions<BenutzerContext> options)
        : base(options)
    {
        
    }

    public BenutzerContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,49154;Database=master;User Id=sa;Password=yourStrong(!)Password2;TrustServerCertificate=true;");
            
        }
    }

   
    public DbSet<Benutzer> Benutzerx { get; set; }
}