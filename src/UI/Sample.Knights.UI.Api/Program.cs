using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using FluentValidation;
using Sample.Knights.UI.Api.Extensions;
using Sample.Utils.Extensions;
using Sample.Knights.Core.Application.Validations;
using Sample.Knights.UI.Api.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(opt => opt.AddSimpleConsole(c => c.TimestampFormat = "[HH:mm:ss] "));
builder.Services.SetupSettings(builder.Configuration);
builder.Services.SetupIoC();
builder.Services.SetupRepositories();

builder.Services.AddControllers(options => 
{
    options.AllowEmptyInputInBodyModelBinding = true;
    options.SetupGlobalRoutePrefix(new RouteAttribute("api"));
    options.Filters.Add(typeof(HttpInterceptionCorrelation));
    options.Filters.Add(typeof(ValidateModelStateAttribute));
})
.AddNewtonsoftJson(options => options.SerializerSettings.SetDefaultJsonSerializerSettings());

builder.Services.AddFluentValidationAutoValidation(options => options.DisableDataAnnotationsValidation = true);
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<KnightInsertValidation>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SchemaFilter<SnakeCaseSchemaFilter>());
builder.WebHost.UseDefaultServiceProvider(options => options.ValidateScopes = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SetupExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
