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

// Add Application Classes
builder.Services.AddSingleton<CosmosDbConfig>();
builder.Services.AddSingleton<CosmosDbService>();
builder.Services.AddSingleton<ContactsStore>();
builder.Services.AddSingleton<ContactsManager>();
builder.Services.AddSingleton<ContactsBusinessLogic>();

string corsPolicyName = "AllowLocalReactApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      policy =>
                      {
                          _ = policy.WithOrigins("http://localhost:5173", "https://localhost:5173/")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
    _ = builder.Configuration.AddUserSecrets<Program>();
}

app.UseCors(corsPolicyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
