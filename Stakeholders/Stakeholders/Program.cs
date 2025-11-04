using DotNetEnv;
using Infrastructure;
using Stakeholders.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

if (builder.Environment.IsDevelopment())
{
    Env.Load();
}

builder.Services.ConfigureStakeholders();
builder.Services.ConfigureCors();
builder.Services.ConfigureAuth(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("_allowDevClients");
app.UseAuthorization();

app.MapControllers();

app.ApplyMigrations();

app.Run();
