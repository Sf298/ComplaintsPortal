using Complaints.Api.Data;
using Complaints.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var originsList = builder.Configuration.GetConnectionString("AllowedOrigins");
if (originsList is not null) {
    var allowedOrigins = originsList.Split(',');
    builder.Services.AddCors(options => options.AddDefaultPolicy(policy => {
        policy.WithOrigins(allowedOrigins)
            .WithMethods("GET", "POST", "DELETE", "PUT")
            .WithHeaders("Content-Type") // <--- list the allowed headers here
            .AllowCredentials()
            .WithExposedHeaders("X-Pagination");
    }));
}
builder.Services.AddRepositories(builder.Configuration);


var app = builder.Build();
await app.Services.InitialiseDbAsync();
if (originsList is not null) {
    app.UseCors();
}

app.MapGet("/", () => {
    Console.WriteLine("saud test");
    return "Hello World!";
});

app.MapComplaintsEndpoints();

app.Run();
