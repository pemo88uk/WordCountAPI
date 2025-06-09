var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Word Count API",
        Version = "v1",
        Description = "Upload a `.txt` file and receive a frequency count of each word in descending order of occurrence.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://your-portfolio-or-company.com")
        }
    });

    c.SupportNonNullableReferenceTypes();
});

var app = builder.Build();

// Enable Swagger with custom styling
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Word Count API v1");
    c.DocumentTitle = "Word Count API";
    c.DefaultModelsExpandDepth(-1);
    c.InjectStylesheet("/swagger-ui/custom.css");
    c.RoutePrefix = "swagger"; // <- back to default
});

// Middleware pipeline
app.UseHttpsRedirection();
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "upload.html" }
});
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();