public interface IRepository
{
	Task<List<Gadget>> GetGadgetsAsync();
	Task<List<Gadget>> GetGadgetsAsync(string name);
	Task<Gadget> GetGadgetAsync(int id);
	Task InsertGadgetAsync(Gadget gadget);
	Task UpdateGadgetAsync(Gadget gadget);
	Task DeleteGadgetAsync(int id);
	Task SaveAsync();
}