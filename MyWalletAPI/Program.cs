using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWalletAPI;
using MyWalletAPI.DbContexts;
using MyWalletAPI.Repositories;
using MyWalletAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyWalletApiDbContext>(e => e.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IPointsStatisticRepository, PointsStatisticRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
