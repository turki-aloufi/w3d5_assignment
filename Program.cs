using EcommerceBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
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

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");

// Sample categories
List<CategoryModel> categories = new List<CategoryModel>
{
    new CategoryModel { Id = 1, Category = "Electronics" },
    new CategoryModel { Id = 2, Category = "Footwear" },
    new CategoryModel { Id = 3, Category = "Computers" },
    new CategoryModel { Id = 4, Category = "Wearables" }
};

// Sample products
List<ProductModel> products = new List<ProductModel>
{
    new ProductModel
    {
        Id = 1,
        Name = "Wireless Headphones",
        CategoryId = "1",
        Description = "Noise-cancelling over-ear headphones with Bluetooth connectivity.",
        Price = 99.99m,
        ImageUrl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRYdE_fuLUfnaOsH5B-c5j265vsuXWwDZRlRORtc_-m_PjzD_XawqKwnqZbTalDxjWRwB4fBUiAAcTdPZ_u4nRTgDbmdFmFH8HPVDdhaEIfu5EEKx0mWhgP_hpo-1YAJwMD6R-GWQ&usqp=CAc"
    },
    new ProductModel
    {
        Id = 2,
        Name = "Smartphone",
        CategoryId = "1",
        Description = "Latest model smartphone with high-resolution camera and fast processor.",
        Price = 699.99m,
        ImageUrl = "data:image/webp;base64,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"
    },
    new ProductModel
    {
        Id = 3,
        Name = "Running Shoes",
        CategoryId = "2",
        Description = "Lightweight and comfortable running shoes for daily training.",
        Price = 59.99m,
        ImageUrl = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTZJJxDNjfMNo5FOHoQ7j8V54n2VK5E9qhZRwUzdqyJDmh42FCOfAnmcOAJIXrY1aWESQBTJO3-hfq6HXuW0YqqKqZWeABPwvQnqi1c886mmWyj58F6qDrhoPIGbwQwQd34o1II3g&usqp=CAc"
    },
    new ProductModel
    {
        Id = 4,
        Name = "Gaming Laptop",
        CategoryId = "3",
        Description = "High-performance gaming laptop with dedicated GPU and fast refresh rate display.",
        Price = 1299.99m,
        ImageUrl = "https://m.media-amazon.com/images/I/71DHV9GZSOL._AC_SX679_.jpg"
    },
    new ProductModel
    {
        Id = 5,
        Name = "Smart Watch",
        CategoryId = "4",
        Description = "Water-resistant smartwatch with heart rate monitoring and GPS.",
        Price = 199.99m,
        ImageUrl = "data:image/webp;base64,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"
    }
};

// Cart items list
List<CartItemModel> cartItems = new();

// Get all products
app.MapGet("/get/products", () =>
{
    return Results.Ok(products);
});

// Get product by ID
app.MapGet("/get/products/{id}", (int id) =>
{
    var product = products.Find(p => p.Id == id);
    return product != null ? Results.Ok(product) : Results.NotFound($"Product with ID {id} not found");
});

// Get all categories
app.MapGet("/get/categories", () =>
{
    return Results.Ok(categories);
});

app.MapPost("/cart/add", (CartItemModel cartItemModel) =>
{
    var product = products.Find(p => p.Id == cartItemModel.Product.Id);
    if (product == null)
        return Results.NotFound($"Product with ID {cartItemModel.Product.Id} not found.");

    var existingCartItem = cartItems.Find(item => item.Product.Id == cartItemModel.Product.Id);
    if (existingCartItem != null)
        existingCartItem.Quantity += cartItemModel.Quantity;
    else
        cartItems.Add(new CartItemModel { Product = product, Quantity = cartItemModel.Quantity });

    return Results.Ok(new { Message = "Item added to cart", Data = cartItems });
});
// Get all cart items
app.MapGet("/get/cart", () => Results.Ok(cartItems));

app.Run();
