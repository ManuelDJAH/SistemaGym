using CapaDatos;

var builder = WebApplication.CreateBuilder(args);

// ── MVC ──────────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ── Sesión ───────────────────────────────────────────────────────
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".SistemaGym.Session";
});

builder.Services.AddHttpContextAccessor();

// ── Cadena de conexión disponible en CapaDatos ───────────────────
// Inyectamos la cadena al iniciar para que Conexion.cs la use
var connStr = builder.Configuration.GetConnectionString("GymDB");
Conexion.SetConnectionString(connStr);

var app = builder.Build();

// ── Pipeline ─────────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();       // ← Antes de Authorization
app.UseAuthorization();

// ── Ruta por defecto → Login ──────────────────────────────────────
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();