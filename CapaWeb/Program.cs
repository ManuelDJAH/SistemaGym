using CapaDatos;

var builder = WebApplication.CreateBuilder(args);

// ── MVC ──────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ── Sesión ───────────────────────────────────────────────────
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(4);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// ── Antiforgery ──────────────────────────────────────────────
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

// ── Inyectar cadena de conexión en CapaDatos ─────────────────
var connStr = builder.Configuration.GetConnectionString("GymDB");
if (!string.IsNullOrEmpty(connStr))
    Conexion.SetCadenaWeb(connStr);

// ── Pipeline ─────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();