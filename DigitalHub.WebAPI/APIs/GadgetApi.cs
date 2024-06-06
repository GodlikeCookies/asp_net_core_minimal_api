public class GadgetApi : IApi
{
	public void Register(WebApplication app)
	{
		app.MapGet("/gadgets", Get)
			.Produces<List<Gadget>>(StatusCodes.Status200OK)
			.WithName("GetAllGadgets")
			.WithTags("Getters");
			
		app.MapGet("/gadgets/{name}", SearchByName)
			.Produces<List<Gadget>>(StatusCodes.Status200OK)
			.WithName("GetGadgetsByName")
			.WithTags("Getters");
		
		app.MapGet("/gadgets/{id:int}", GetById)
			.Produces<Gadget>(StatusCodes.Status200OK)
			.WithName("GetGadgetById")
			.WithTags("Getters");
			
		app.MapPost("/gadgets", Post)
			.Accepts<Gadget>("application/json")
			.Produces<Gadget>(StatusCodes.Status201Created)
			.WithName("CreateGadget")
			.WithTags("Creators");
		
		app.MapPut("/gadgets/{id}", Put)
			.Accepts<Gadget>("application/json")
			.WithName("UpdateGadget")
			.WithTags("Updaters");
		
		app.MapDelete("/gadgets/{id}", Delete)
			.WithName("DeleteGadget")
			.WithTags("Deleters");
	}
	
	private async Task<IResult> Get (IRepository repository) =>
		Results.Json(await repository.GetGadgetsAsync());
	private async Task<IResult> SearchByName (string name, IRepository repository) =>
		await repository.GetGadgetsAsync(name) is List<Gadget> gadgets
		? Results.Ok(gadgets)
		: Results.NotFound();
	private async Task<IResult> GetById (int id, IRepository repository) =>
		await repository.GetGadgetAsync(id) is Gadget gadget
		? Results.Ok(gadget)
		: Results.NotFound();
	private async Task<IResult> Post ([FromBody] Gadget gadget, IRepository repository)
	{
		await repository.InsertGadgetAsync(gadget);
		await repository.SaveAsync();
		return Results.Created($"/gadgets/{gadget.Id}", gadget);
	}
	private async Task<IResult> Put (int id, [FromBody] Gadget gadget, IRepository repository)
	{
		await repository.UpdateGadgetAsync(gadget);
		await repository.SaveAsync();
		return Results.NoContent();
	}
	private async Task<IResult> Delete (int id, IRepository repository)
	{
		await repository.DeleteGadgetAsync(id);
		await repository.SaveAsync();
		return Results.NoContent();
	}
}