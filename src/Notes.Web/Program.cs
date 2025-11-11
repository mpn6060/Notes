using Microsoft.EntityFrameworkCore;
using Notes.Infrastructure.Persistence;
using Notes.Infrastructure.Services;
using Notes.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); //.AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();          

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notes}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
