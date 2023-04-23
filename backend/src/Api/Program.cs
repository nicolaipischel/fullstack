global using FastEndpoints;
global using FluentValidation;
using Api;
using FastEndpoints.ClientGen;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

var myallowedSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(o =>
{
    o.AddPolicy(
        name: myallowedSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
app.UseCors(myallowedSpecificOrigins);

app.MapTypeScriptClientEndpoint("/typescript", "v1", settings: s =>
{
    s.ClassName = "apiClient";
    s.GenerateClientClasses = true;
    s.TypeScriptGeneratorSettings.Namespace = "api.client";
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Run();
