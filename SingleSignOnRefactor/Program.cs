using SingleSignOnRefactor.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AuthenticationSetup.AuthenticationConfiguration(builder.Services);

DependencyInjectionConfiguration.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UserEndPointsConfiguration();

app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

