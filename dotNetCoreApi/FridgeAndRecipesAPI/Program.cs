using FridgeAPI = FridgeAndRecipesAPI;
using FridgeAndRecipesStorage.Fridge;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyOrigin",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000");
                      });
});// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyOrigin");


app.UseAuthorization();

app.MapControllers();

FridgeAPI.FridgeState.FridgeSession = FridgeGateway.OpenFridge();
FridgeAPI.RecipeState.RecipesSession = new FridgeAndRecipesStorage.Recipies.RecipesCollection();
app.Run();
