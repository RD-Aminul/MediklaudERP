
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.Pharmacy.Entry;
using mediklaud_api.Interface.SignIn;
using mediklaud_api.Service.Pharmacy.Entry;
using mediklaud_api.Service.SignIn;
using mediklaud_api.Interface.Pharmacy;
using mediklaud_api.Service.Pharmacy;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IPhrPurchaseRequisitionService, PharPurchaseRequisitionService>();
builder.Services.AddTransient<IPhrPurchaseReceiveService, PhrPurchaseReceiveService>();
builder.Services.AddTransient<IPhrBillingService, PhrBillingService>();
builder.Services.AddTransient<ISignInService, SignInService>();
builder.Services.AddTransient<IPhrGRNService, PhrGRNService>();

builder.Services.AddSingleton<IMediklaudDBConnection, MediklaudDBConnection>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
       .WithOrigins(
       "http://localhost:3000", 
       "https://localhost:3000", 
       "https://192.168.100.89:3000", 
       "http://192.168.100.89:3000", 
       "http://123.200.7.234:3000", 
       "https://123.200.7.234:3000", 
       "http://localhost:11254", 
       "http://localhost:8080", 
       "http://localhost:11254", 
       "https://localhost:11254",
       "http://localhost:15266",
       "https://localhost:15266",
       "https://localhost:44347/WebForm1.aspx", 
       "http://localhost:44347/WebForm1.aspx")
       .SetIsOriginAllowedToAllowWildcardSubdomains()
       .AllowAnyHeader()
       .AllowCredentials()
       .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
       .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
}

);
app.UseCors();


app.MapControllers();
app.Run();
