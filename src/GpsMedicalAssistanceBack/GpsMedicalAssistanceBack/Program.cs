using GpsMedicalAssistanceBack.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.ConfigureCors();
    builder.Services.ConfigureDbContext(builder.Configuration);
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureRepositoryServices();
    builder.Services.ConfigureTwilioSettings(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(Program));

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("CorsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

