var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.MapGet("/", () => "Hello World");

app.MapControllerRoute
    (

         name: "default",
         pattern: "{Controller=Home}/{Action=Index}/{id?}"

    );
// wwwroot dosya deste�ini aktif et
app.UseStaticFiles(); // wwwroot klas�r�ndeki dosyalar� eri�ilebilir yapar.
app.Run();
