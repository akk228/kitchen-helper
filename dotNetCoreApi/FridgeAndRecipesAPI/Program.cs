using FridgeAPI = FridgeAndRecipesAPI;
using FridgeAndRecipesStorage.Fridge;
using System.Text.Json.Serialization;
using FridgeAndRecipesStorage.Gateway;
using FridgeAndRecipesStorage.Recipies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Fridge>();
builder.Services.AddTransient<RecipesCollection>();

builder.Services.AddTransient(typeof(Gateway<>));

builder.Services.ConfigureHttpJsonOptions(options => 
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyOrigin",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000");
                      });
});// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options => 
    options.AddDefaultPolicy(policy => 
        policy.WithOrigins("http://localhost:3000")
));
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

app.Run();
