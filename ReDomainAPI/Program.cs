using System.Text;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("my-secret-key-is-long-enough-32chars!")),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new LoginService("my-secret-key-is-long-enough-32chars!"));


builder.Services.AddSingleton<User>(_ =>
{
    var user = new User("Roy");
    user.SetBet(1000);
    return user;
});

builder.Services.AddSingleton<SlotMachine>(_ =>
{
    var slot = new SlotMachine(new List<List<string>>()
        {
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
            new List<string>() { "J", "Q", "K", "$", "$", "$" },
        },
        new RandomNumberGenerator(6),
        new PayTable()); 
        return slot; 
}
    );


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowAngular");

app.MapControllers();

app.Run();