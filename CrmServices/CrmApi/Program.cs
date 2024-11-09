using CrmApi.BusinessLogic;
using CrmApi.Configurations;
using CrmApi.Domain;
using CrmApi.Mappers;
using CrmApi.Storage;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configurations
builder.Services.Configure<CosmosDbConfig>(builder.Configuration.GetSection(CosmosDbConfig.ConfigName));

// Add Mappers
builder.Services.AddSingleton<ContactMapper>();

// Add Applicaiton Classes
builder.Services.AddSingleton<CosmosDbConfig>();
builder.Services.AddSingleton<CosmosDbService>();
builder.Services.AddSingleton<ContactsStore>();
builder.Services.AddSingleton<ContactsManager>();
builder.Services.AddSingleton<ContactsBusinessLogic>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
