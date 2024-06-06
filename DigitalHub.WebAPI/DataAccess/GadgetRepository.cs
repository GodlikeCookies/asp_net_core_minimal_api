
public class GadgetRepository : IRepository
{
	private readonly AppDbContext _context;
	
	public GadgetRepository(AppDbContext context) => _context = context;
	
	public Task<List<Gadget>> GetGadgetsAsync() => _context.Gadgets.ToListAsync();
	public Task<List<Gadget>> GetGadgetsAsync(string name) =>
		_context.Gadgets.Where(g => g.Name.Contains(name)).ToListAsync();
	public async Task<Gadget> GetGadgetAsync(int id) =>
		await _context.Gadgets.FindAsync(new object[] {id});
	public async Task InsertGadgetAsync(Gadget gadget) =>
		await _context.Gadgets.AddAsync(gadget);
	public async Task UpdateGadgetAsync(Gadget gadget)
	{	
		var gadgetFromDb = await _context.Gadgets.FindAsync(new object[] {gadget.Id});
		if (gadgetFromDb is null) return;
		_context.Entry(gadgetFromDb).CurrentValues.SetValues(gadget);
	}
	public async Task DeleteGadgetAsync(int id)
	{
		var gadgetFromDb = await _context.Gadgets.FindAsync(new object[] {id});
		if (gadgetFromDb is null) return;
		_context.Gadgets.Remove(gadgetFromDb);
	}
	public async Task SaveAsync() => await _context.SaveChangesAsync();
}
