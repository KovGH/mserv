using Microsoft.EntityFrameworkCore;

namespace Seminar;

public class ProduktContext : DbContext
{
    public ProduktContext(DbContextOptions<ProduktContext> 
        options)
        : base(options)
    {
        
    }

    public ProduktContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=true;");
            
        }
    }
    
    public DbSet<Produkt> Produkte { get; set; }
}