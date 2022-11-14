using Application.Customers;
using Infra;
using ReadInfra;
using Microsoft.EntityFrameworkCore;
using Infra.CustomersRepository;
using Domain.Customers.Services;
using Services.Customers.QueryHandlers;
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ReadDataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ReadModelConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ApplicationContract.Customers.ServiceContracts.ICustomerService,CreateCommandHandler>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ServiceContracts.Customers.Contracts.ICustomerService, CustomerServiceQueryHandler>();
builder.Services.AddScoped<ICustomerDomainService, CustomerDomainService>();

builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();