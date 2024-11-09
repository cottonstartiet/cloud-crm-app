using CrmApi.BusinessLogic;
using CrmApi.Mappers;
using CrmApi.Utils;

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
