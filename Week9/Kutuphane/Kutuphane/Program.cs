var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.MapGet("/", () => "Hello World");

app.MapControllerRoute
    (

         name: "default",
         pattern: "{Controller=Home}/{Action=Index}/{id?}"

    );
// wwwroot dosya desteðini aktif et
app.UseStaticFiles(); // wwwroot klasöründeki dosyalarý eriþilebilir yapar.
app.Run();
