using Microsoft.EntityFrameworkCore;
using TodoList.Components;
using TodoList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// register in-memory singleton service used elsewhere (studenti sample)
//builder.Services.AddSingleton<TodoList.Services.StudentiService>();

// register ClassiService as scoped; the service will create HttpClient instances
// at runtime using NavigationManager to compute the correct base URI.
builder.Services.AddScoped<TodoList.Services.ClassiService>();
// Register API controllers so that routes like "api/classi" are exposed
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Map API controllers
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList v1"));
}

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
