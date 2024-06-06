var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

var apis = app.Services.GetServices<IApi>();
foreach (var api in apis)
{
	if (api is null) throw new InvalidProgramException($"Api {api.GetType()} not found");
	api.Register(app);
}

app.Run();

void RegisterServices(IServiceCollection services)
{
	services.AddEndpointsApiExplorer();
	services.AddSwaggerGen();
	services.AddDbContext<AppDbContext>(options => 
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	});
	services.AddScoped<IRepository, GadgetRepository>();
	services.AddTransient<IApi, GadgetApi>();
}

void Configure(WebApplication app)
{
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}
	app.UseHttpsRedirection();
}
