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

app.UseHttpsRedirection();

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
app.MapPost("/api/seller", (BangazonDbContext db, Seller seller) =>
{
    db.Sellers.Add(seller);
    db.SaveChanges();
    return Results.Created($"/api/seller/{seller.Id}", seller);
});

app.MapGet("/api/stores", (BangazonDbContext db) => db.Stores.ToList());
app.MapGet("/api/store/{id}", (BangazonDbContext db, int id) =>
{
    return db.Stores.Include(s => s.Seller).SingleOrDefault(s => s.Id == id);
});

app.MapGet("/api/products", (BangazonDbContext db) => db.Products.ToList());

app.MapGet("/api/customers", (BangazonDbContext db) => db.Customers.ToList());
app.MapGet("/api/customer/{id}", (BangazonDbContext db, int id) =>
{
    return db.Customers.Include(c => c.User).Single(c => c.Id == id);
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

app.MapGet("/api/order-items/{id}", (BangazonDbContext db, int id) =>
{
    return db.OrderItems
        .Include(o => o.Order)
        .Include(o => o.Product)
        .SingleOrDefault(o => o.Id == id);
});
app.MapPost("/api/order-items", (BangazonDbContext db, OrderItems orderItems ) =>
{
    db.OrderItems.Add(orderItems);
    db.SaveChanges();
    return Results.Created($"/api/order-items/{orderItems.Id}", orderItems);
});

app.MapGet("/api/orders", (BangazonDbContext db) => db.Orders.ToList());
app.MapGet("/api/order/{id}", (BangazonDbContext db, int id) =>
{
    return db.Orders.Include(o => o.Customer).SingleOrDefault(o => o.Id == id);
});
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

// ===================================================================================================================
app.Run();
