using Coupons.Service.Infrastructure.Extentions;
using Coupons.Service.Application.Extentions;
using Coupon.Service.API.Middleware;
using FluentValidation.AspNetCore;
using Coupon.Service.Application.CQRS.Command.CouponeCreate;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCouponeApplication();
builder.Services.AddCouponeInfrastructure(builder.Configuration);





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await CouponeInfrastructureExtention.AddCouponeSeeder(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
