var builder = WebApplication.CreateBuilder(args);
SeedData.Init();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiContext>();

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();