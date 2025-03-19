using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowMobileApp", policy =>
//     { 
//         policy.WithOrigins("http://localhost:8081", "http://10.0.0.42") // For RN: Add your mobile app's IP or Expo URL
//             .AllowAnyHeader()
//             .AllowAnyMethod();
//     });
// });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Check comment below this line.
// Add this above the `var app = builder.Build();` line. The middle statement is the most important since it makes an
// instance of the BanganzonDbContext class available to our endpoints.

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
#endregion

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ============================================== Endpoints  ==============================================
app.MapGet("/api/users", (BangazonDbContext db) => db.Users.ToList());
app.MapPost("/api/user", (BangazonDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges(); // Inherited method from the DbContextClass
    return Results.Created($"/api/user/{user.Id}", user); // Creates a 201 response
});
app.MapDelete("/api/user/{id}", (BangazonDbContext db, int id) =>
{
    User? userToDelete = db.Users.SingleOrDefault(u => u.Id == id);
    db.Users.Remove(userToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/api/seller/{id}", (BangazonDbContext db, int id) =>
{
    Seller? seller = db.Sellers.SingleOrDefault(u => u.Id == id);
    if (seller == null)
    {
        return Results.NotFound();
    }
    db.Sellers.Remove(seller);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/sellers", (BangazonDbContext db) =>  db.Sellers.ToList());
app.MapGet("/api/seller/{id}", (BangazonDbContext db, int id) =>
{
    return db.Sellers
        .Include(s => s.Stores)
        .ThenInclude(s => s.Products)
        .SingleOrDefault(u => u.Id == id);
});
app.MapPost("/api/seller", (BangazonDbContext db, Seller seller) =>
{
    db.Sellers.Add(seller);
    db.SaveChanges();
    return Results.Created($"/api/seller/{seller.Id}", seller);
});

app.MapGet("/api/stores", (BangazonDbContext db) =>
{
    return db.Stores
        .Include(s => s.Seller)
        .ToList();
});
app.MapGet("/api/store/{id}", (BangazonDbContext db, int id) =>
{
    return db.Stores
        .Include(s => s.Seller)
        .Include(s => s.Products)
        .SingleOrDefault(s => s.Id == id);
});
app.MapPost("/api/store", (BangazonDbContext db, Store store) =>
{
    db.Stores.Add(store);
    db.SaveChanges();
    return Results.Created($"/api/store/{store.Id}", store);
});

app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products
        .Include(p => p.Store)
        .ThenInclude(p => p.Seller)
        .ToList();
});
app.MapGet("/api/products/latest", (BangazonDbContext db) =>
{
    return db.Products
        .Include(p => p.Store)
        .ThenInclude(s => s.Seller)
        .AsEnumerable()
        .OrderBy(p => p.DateAdded).Take(20).Reverse();
});
app.MapGet("/api/product/{id}", (BangazonDbContext db, int id) =>
{
    return db.Products
        .Include(p => p.Store)
        .ThenInclude(p => p.Seller)
        .SingleOrDefault(p => p.Id == id);
});
app.MapPost("/api/product", (BangazonDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/api/product/{product.Id}", product);
});
app.MapPut("/api/product/{id}", (BangazonDbContext db, int id, Product product) =>
{
    Product? productToUpdate = db.Products.SingleOrDefault(p => p.Id == id);
    if (productToUpdate == null)
    {
        return Results.NotFound();
    }
    productToUpdate.Category = product.Category;
    productToUpdate.Name = product.Name;
    productToUpdate.Description = product.Description;
    productToUpdate.Price = product.Price;
    productToUpdate.QuantityAvailable = product.QuantityAvailable;
    productToUpdate.StoreId = product.Store.Id;
    db.SaveChanges();
    
    return Results.NoContent();
});
app.MapDelete("/api/product/{id}", (BangazonDbContext db, int id) =>
{
    Product? productToDelete = db.Products.SingleOrDefault(p => p.Id == id);
    if (productToDelete == null)
    {
        return Results.NotFound();
    }
    db.Products.Remove(productToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/api/customers", (BangazonDbContext db) => db.Customers.ToList());
app.MapGet("/api/customer/{id}", (BangazonDbContext db, int id) =>
{
    return db.Customers
        .Include(c => c.User)
        .Include(c => c.Orders)
        .Include(c => c.PaymentMethods)
        .SingleOrDefault(c => c.Id == id);
});
// GET Customer by uid.
app.MapGet("/api/customer", (BangazonDbContext db, string uid) =>
{
    return db.Customers
        .Include(c => c.Orders)
        .ThenInclude(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
        .SingleOrDefault(c => c.Uid == uid);
});
app.MapPost("/api/customer", (BangazonDbContext db, Customer customer) =>
{
    db.Customers.Add(customer);
    db.SaveChanges();
    return Results.Created($"/api/customer/{customer.Id}", customer);
});

app.MapDelete("/api/customer/{id}", (BangazonDbContext db, int id) =>
{
    Customer? customerToDelete = db.Customers.SingleOrDefault(c => c.Id == id);
    if (customerToDelete == null)
    {
        return Results.NotFound();
    }

    db.Customers.Remove(customerToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

// GET a single order items.
app.MapGet("/api/orders/{orderId}/items", (BangazonDbContext db, int orderId) =>
{
   var orderItems = db.OrderItems
        .Where(oi => oi.OrderId == orderId)
        .Include(oi => oi.Order)
        .Include(oi => oi.Product)
        .Select(oi => new
        {
            OrderId = oi.OrderId,
            ProductId = oi.Product.Id,
            ProductName = oi.Product.Name,
            ProductPrice = oi.Product.Price,
            OrderTotal = oi.Order.OrderTotal,
            OrderDate = oi.Order.OrderDate,
        })
        .ToList();
   if (orderItems == null || orderItems.Count == 0)
   {
       return Results.NotFound($"No order items found for order {orderId}");
   }
   return Results.Ok(orderItems);
});
// GET Customer's orders. TODO: MIGHT NOT NEED ANYMORE
app.MapGet("/api/customer/{customerId}/orders", (BangazonDbContext db, int customerId) =>
{
    var customerOrders = db.Orders
        .Where(o => o.CustomerId == customerId)
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
        .ToList();
    return Results.Ok(customerOrders);
});

app.MapGet("/api/order/{id}", (BangazonDbContext db, int id) =>
{
    return db.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
        .ThenInclude(p => p.Store)
        .SingleOrDefault(o => o.Id == id);
});
app.MapGet("/api/orders/history", (BangazonDbContext db, string uid) =>
{
    var customerOrders = db.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
        // .ThenInclude(p => p.Store)
        .Where(o => o.Customer.Uid == uid)
        .ToList();
    return customerOrders.Count == 0 ? Results.NotFound() : Results.Ok(customerOrders);
});
// app.MapGet("api/orders",  (BangazonDbContext db, string uid) =>
// {
//     var customerOrders = db.Orders
//         .Where(o => o.Customer.Uid == uid)
//         .Include(o => o.OrderItems)
//         .ThenInclude(oi => oi.Product)
//         .ToList();
// //     return Results.Ok(customerOrders);
// });
app.MapPost("/api/order", (BangazonDbContext db, Order order) =>
{
    db.Orders.Add(order);
    db.SaveChanges();
    return Results.Created($"/api/order/{order.Id}", order);
});

app.MapGet("/api/payment-methods", (BangazonDbContext db) =>  db.PaymentMethods.ToList());
app.MapPost("/api/payment-method", (BangazonDbContext db, PaymentMethod paymentMethod) =>
{
    db.PaymentMethods.Add(paymentMethod);
    db.SaveChanges();
    return Results.Created($"/api/customer/payment-method/{paymentMethod.Id}", paymentMethod);
});
app.MapDelete("/api/payment-method/{id}", (BangazonDbContext db, int id) =>
{
    PaymentMethod? paymentMethodToDelete = db.PaymentMethods.SingleOrDefault(pm => pm.Id == id);
    if (paymentMethodToDelete == null)
    {
        return Results.NotFound();
    }
    db.PaymentMethods.Remove(paymentMethodToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/customer/{id}", (BangazonDbContext db, int id, Customer customer) =>
{
    Customer? customerToUpdate = db.Customers.SingleOrDefault(c => c.Id == id);
    if (customerToUpdate == null)
    {
        return Results.NotFound();
    }
    customerToUpdate.FirstName = customer.FirstName;
    customerToUpdate.LastName = customer.LastName;
    customerToUpdate.Address = customer.Address;
    customerToUpdate.City = customer.City;
    customerToUpdate.State = customer.State;
    customerToUpdate.ZipCode = customer.ZipCode;
    
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/sellers/{id}", (BangazonDbContext db, int id, Seller seller) =>
{
    Seller? sellerToUpdate = db.Sellers.SingleOrDefault(s => s.Id == id);
    if (sellerToUpdate == null)
    {
        return Results.NotFound();
    }
    sellerToUpdate.Username = seller.Username;
    
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/api/payment-methods/{id}", (BangazonDbContext db, int id, PaymentMethod paymentMethod) =>
{
    PaymentMethod? paymentMethodToUpdate = db.PaymentMethods.SingleOrDefault(pm => pm.Id == id);
    if (paymentMethodToUpdate == null)
    {
        return Results.NotFound();
    }
    paymentMethodToUpdate.CardNumber = paymentMethod.CardNumber;
    paymentMethodToUpdate.SecurityCode = paymentMethod.SecurityCode;
    paymentMethodToUpdate.ExpirationDate = paymentMethod.ExpirationDate;

    db.SaveChanges();
    return Results.NoContent();
});

// Query parameters must be handled in lambda expression, not in the route.
app.MapGet("/api/user", (BangazonDbContext db, string? uid) =>
{
    User? userToLocate = db.Users.SingleOrDefault(u => u.Uid == uid);
    if (userToLocate == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(userToLocate);
});
// ===================================================================================================================
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
