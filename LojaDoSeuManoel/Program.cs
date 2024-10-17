using AutoMapper;
using LojaDoSeuManoel.AutoMappers;
using LojaDoSeuManoel.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(OrderMap));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API de Embalagem de Pedidos - Loja do Seu Manoel", Version = "v1" });
});
builder.Services.AddScoped<IOrderService, OrderService>();
var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Embalagem de Pedidos");
});

app.Run();
