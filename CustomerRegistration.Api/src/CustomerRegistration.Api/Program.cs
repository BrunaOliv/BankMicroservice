using CustomerRegistration.Application.Commands.CreateCustomer;
using CustomerRegistration.Application.Mappings;
using CustomerRegistration.Domain.Interfaces;
using CustomerRegistration.Infra.Consumer.Consumers;
using CustomerRegistration.Infra.Data.Repositories;
using CustomerRegistration.Infra.Publisher.Publishers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateCustomerCommand).Assembly);

builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();

builder.Services.AddHostedService<MessageConsumer>();

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
