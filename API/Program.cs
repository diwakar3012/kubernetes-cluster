var builder = WebApplication.CreateBuilder(args);


string secretsPath = "/mnt/secrets-store";

// Example: Reading a specific secret
string secretFileName = "dbname"; // Replace with your secret name
string secretFilePath = Path.Combine(secretsPath, secretFileName);

if (File.Exists(secretFilePath))
{
    string secretValue = File.ReadAllText(secretFilePath);
    Console.WriteLine($"Secret Value for {secretFileName}: {secretValue}");
}
else
{
    Console.WriteLine($"Secret file {secretFileName} does not exist at path {secretsPath}.");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "DemoK8sAPI",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});


// Disable HTTPS redirection
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.HttpsPort = null; // Disable the middleware
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors("DemoK8sAPI");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
