# CodeFirstBasic Projesi README

Bu proje, Entity Framework Core ve SQL Server kullanarak temel bir Code-First yaklaþýmýný göstermektedir. Proje, `Game` (Oyun) ve `Movie` (Film) olmak üzere iki varlýðý yönetmektedir.

## Proje Yapýsý

-   **CodeFirstBasic.Context**: Entity Framework Core baðlamý olan `PatikaFirstDbContext` sýnýfýný içerir.
-   **CodeFirstBasic.Entities.Game**: Oyun varlýðýný temsil eden `GameEntity` sýnýfýný içerir.
-   **CodeFirstBasic.Entities.Movie**: Film varlýðýný temsil eden `MovieEntity` sýnýfýný içerir.

## Baðýmlýlýklar

-   Microsoft.EntityFrameworkCore
-   Microsoft.EntityFrameworkCore.SqlServer

## Kurulum ve Yapýlandýrma

1.  **Gerekli NuGet Paketlerini Yükleyin:**

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    ```

2.  **Veritabaný Baðlantýsýný Yapýlandýrýn:**

    -   `PatikaFirstDbContext.cs` dosyasýndaki `OnConfiguring` metodu, SQL Server için baðlantý dizesini ayarlar.
    -   **Önemli:** Baðlantý dizesini kendi SQL Server örneðinizin detaylarýyla güncelleyin.

        ```csharp
        optionsBuilder.UseSqlServer(@"Server=HURGENC\SQLEXPRESS;Database=PatikaCodeFirstDb1;Trusted_Connection=True;TrustServerCertificate=True;");
        ```

    -   `HURGENC\SQLEXPRESS` kýsmýný kendi sunucu adýnýzla ve `PatikaCodeFirstDb1` kýsmýný istediðiniz veritabaný adýyla deðiþtirin. SQL Server örneðinizin çalýþtýðýndan ve eriþilebilir olduðundan emin olun.

3.  **Varlýk Tanýmlarý:**

    -   **GameEntity (Oyun Varlýðý):**
        -   `Id` (int): Birincil anahtar.
        -   `Name` (string): Oyunun adý.
        -   `Platform` (string): Oyunun mevcut olduðu platform.
        -   `Rating` (decimal): Oyunun puaný, toplamda 3 basamak ve ondalýk kýsýmdan sonra 1 basamak hassasiyetle (örneðin, 7.5).
    -   **MovieEntity (Film Varlýðý):**
        -   `Id` (int): Birincil anahtar.
        -   `Title` (string): Filmin adý.
        -   `Genre` (string): Filmin türü.
        -   `ReleaseYear` (int): Filmin yayýn yýlý.

4.  **Veritabaný Oluþturma ve Migrasyonlar:**

    -   **Migrasyonlarý Ekleyin:**

        ```bash
        dotnet ef migrations add InitialCreate
        ```

    -   **Veritabanýný Güncelleyin:**

        ```bash
        dotnet ef database update
        ```

    -   Bu komutlar, kodunuzdaki varlýk tanýmlarýna göre veritabanýný ve tablolarý oluþturur.

5.  **Model Yapýlandýrmasý:**

    -   `PatikaFirstDbContext.cs` dosyasýndaki `OnModelCreating` metodu, modeli yapýlandýrmak için kullanýlýr:
        -   `modelBuilder.Entity<MovieEntity>().ToTable("Movies");` ve `modelBuilder.Entity<GameEntity>().ToTable("Games");` varlýklar için tablo adlarýný ayarlar.
        -   `modelBuilder.Entity<GameEntity>().Property(g => g.Rating).HasPrecision(3, 1);` `GameEntity`'nin `Rating` özelliðinin hassasiyetini ve ölçeðini yapýlandýrýr.

## Kullaným

Migrasyonlarý çalýþtýrdýktan sonra, `PatikaFirstDbContext`'i `Game` ve `Movie` varlýklarý üzerinde CRUD iþlemleri gerçekleþtirmek için kullanabilirsiniz.

Örnek:

```csharp
using CodeFirstBasic.Context;
using CodeFirstBasic.Entities.Game;
using CodeFirstBasic.Entities.Movie;

// ...

using (var context = new PatikaFirstDbContext())
{
    // Yeni bir oyun ekle
    var newGame = new GameEntity { Name = "Örnek Oyun", Platform = "PC", Rating = 8.5m };
    context.Games.Add(newGame);
    context.SaveChanges();

    // Yeni bir film ekle
    var newMovie = new MovieEntity { Title = "Örnek Film", Genre = "Aksiyon", ReleaseYear = 2023 };
    context.Movies.Add(newMovie);
    context.SaveChanges();

    // Oyunlarý al
    var games = context.Games.ToList();

    // Filmleri al
    var movies = context.Movies.ToList();

    // ...
}