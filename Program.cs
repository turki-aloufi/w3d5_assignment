using EcommerceBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularApp", policy =>
      policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
  return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "Wireless Headphones",
                    Category = "Electronics",
                    Description = "Noise-cancelling over-ear headphones with Bluetooth connectivity.",
                    Price = 99.99m,
                    ImageUrl = "https://example.com/images/headphones.jpg"
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Smartphone",
                    Category = "Electronics",
                    Description = "Latest model smartphone with high-resolution camera and fast processor.",
                    Price = 699.99m,
                    ImageUrl = "https://example.com/images/smartphone.jpg"
                },
                new ProductModel
                {
                    Id = 3,
                    Name = "Running Shoes",
                    Category = "Footwear",
                    Description = "Lightweight and comfortable running shoes for daily training.",
                    Price = 59.99m,
                    ImageUrl = "https://example.com/images/shoes.jpg"
                },
                new ProductModel
                {
                    Id = 4,
                    Name = "Gaming Laptop",
                    Category = "Computers",
                    Description = "High-performance gaming laptop with dedicated GPU and fast refresh rate display.",
                    Price = 1299.99m,
                    ImageUrl = "https://example.com/images/laptop.jpg"
                },
                new ProductModel
                {
                    Id = 5,
                    Name = "Smart Watch",
                    Category = "Wearables",
                    Description = "Water-resistant smartwatch with heart rate monitoring and GPS.",
                    Price = 199.99m,
                    ImageUrl = "https://example.com/images/smartwatch.jpg"
                }
            };
List<CartItemModel> cartItems = new List<CartItemModel>();
app.MapGet("/get/products", () =>
{
  // List<string> products = ["Laptop", "Tablet"];
  return Results.Ok(products);
});
// app.MapPost("");
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
