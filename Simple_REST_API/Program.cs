using Simple_REST_API.Business.Installers;
using Simple_REST_API.Business.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallCustomServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExpHandlerMiddleware>();
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
