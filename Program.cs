using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using ModularMonolith_DecoupledBoundaries.BillingModule;
using ModularMonolith_DecoupledBoundaries.DomainEvents;
using ModularMonolith_DecoupledBoundaries.DomainEvents.Interfaces;
using ModularMonolith_DecoupledBoundaries.NotificationModule;
using ModularMonolith_DecoupledBoundaries.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// API Versioning  
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Swagger  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Modular Monolith API", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Modular Monolith API", Version = "v2" });
});

builder.Services.AddDbContext<BillingDbContext>(options =>
    options.UseInMemoryDatabase("BillingDb"));

builder.Services.AddDbContext<NotificationsDbContext>(options =>
    options.UseInMemoryDatabase("NotificationsDb"));

// Register dispatcher  
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

// Register services  
builder.Services.AddScoped<BillingService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ReportingService>();
builder.Services.AddScoped<UserService>();

// Register event handlers explicitly  
builder.Services.AddScoped<IDomainEventHandler<InvoiceSentEvent>, NotificationService>();
builder.Services.AddScoped<IDomainEventHandler<CustomerChargedEvent>, NotificationService>();
//builder.Services.AddScoped<IDomainEventHandler<MonthEndedEvent>, ReportingService>();
//builder.Services.AddScoped<IDomainEventHandler<UserInactiveEvent>, UserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
});

app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BillingDbContext>();

    if (!db.Invoices.Any())
    {
        db.Invoices.AddRange(
            new Invoice { Amount = 100 },
            new Invoice { Amount = 250 },
            new Invoice { Amount = 500 }
        );
        db.SaveChanges();
    }
}


app.Run();
