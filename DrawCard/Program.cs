using DrawCard.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRandomCardService, RandomCardService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7116")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowSpecificOrigins");
app.Run();
