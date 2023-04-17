using AutoMapper;
using minimalApi;
using minimalApi.Db;
using minimalApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//routes for database
app.MapGet("/api/pizzas", (ILogger<Program> _logger) =>
{
    _logger.Log(LogLevel.Information, "Getting all records");
    return PizzaDB.GetPizzas();
}).WithName("GetPizzas").Produces<IEnumerable<Pizza>>(200);

app.MapGet("/api/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));

app.MapPost("/api/pizzas", (IMapper _mapper, PizzaCreatedDTO pizza_C_DTO) =>
{
    Pizza pizza = _mapper.Map<Pizza>(pizza_C_DTO);
    PizzaDB.CreatePizza(pizza);
});

app.MapPut("/api/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));

app.MapDelete("/api/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));


app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
