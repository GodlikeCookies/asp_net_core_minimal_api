public class AppDbContext : DbContext
{
	public DbSet<Category> Categories => Set<Category>();
	public DbSet<Gadget> Gadgets => Set<Gadget>();
	
	
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}