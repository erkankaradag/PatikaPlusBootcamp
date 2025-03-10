var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.MapGet("/", () => "Hello World");

app.MapControllerRoute
    (

         name: "default",
         pattern: "{Controller=Home}/{Action=Index}/{id?}"

    );
// wwwroot dosya desteğini aktif et
app.UseStaticFiles(); // wwwroot klasöründeki dosyaları erişilebilir yapar.
app.Run();
