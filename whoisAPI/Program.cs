var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Register controllers
builder.Services.AddHttpClient();  // Register HttpClientFactory
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ✅ Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5000") // React frontend origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Configure the WebHost to listen on both HTTP and HTTPS
builder.WebHost.UseUrls("http://localhost:5133");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors();

app.UseAuthorization();

app.MapControllers(); // Enable attribute routing for your API controllers

app.Run();
