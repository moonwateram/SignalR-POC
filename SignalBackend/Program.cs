using Business;
using Contracts;
using Infrastructure.Repo;
using SignalBackend.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
     builder.WithOrigins("http://localhost:5173")
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        );
});

builder.Services.AddSignalR(opt =>
{
    opt.EnableDetailedErrors = true;
});

// Configurations

// App
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependencies
builder.Services.AddSingleton<ITicketManagement, TicketManagement>();
builder.Services.AddSingleton<ITicketRepository, TicketRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseCookiePolicy();

app.MapHub<TicketHub>("/tickethub");
app.MapHub<TicketHubStreaming>("/tickethub/streaming");

app.Run();