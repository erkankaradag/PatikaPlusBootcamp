# CodeFirstBasic Projesi README

Bu proje, Entity Framework Core ve SQL Server kullanarak temel bir Code-First yakla��m�n� g�stermektedir. Proje, `Game` (Oyun) ve `Movie` (Film) olmak �zere iki varl��� y�netmektedir.

## Proje Yap�s�

-   **CodeFirstBasic.Context**: Entity Framework Core ba�lam� olan `PatikaFirstDbContext` s�n�f�n� i�erir.
-   **CodeFirstBasic.Entities.Game**: Oyun varl���n� temsil eden `GameEntity` s�n�f�n� i�erir.
-   **CodeFirstBasic.Entities.Movie**: Film varl���n� temsil eden `MovieEntity` s�n�f�n� i�erir.

## Ba��ml�l�klar

-   Microsoft.EntityFrameworkCore
-   Microsoft.EntityFrameworkCore.SqlServer

## Kurulum ve Yap�land�rma

1.  **Gerekli NuGet Paketlerini Y�kleyin:**

    ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    ```

2.  **Veritaban� Ba�lant�s�n� Yap�land�r�n:**

    -   `PatikaFirstDbContext.cs` dosyas�ndaki `OnConfiguring` metodu, SQL Server i�in ba�lant� dizesini ayarlar.
    -   **�nemli:** Ba�lant� dizesini kendi SQL Server �rne�inizin detaylar�yla g�ncelleyin.

        ```csharp
        optionsBuilder.UseSqlServer(@"Server=HURGENC\SQLEXPRESS;Database=PatikaCodeFirstDb1;Trusted_Connection=True;TrustServerCertificate=True;");
        ```

    -   `HURGENC\SQLEXPRESS` k�sm�n� kendi sunucu ad�n�zla ve `PatikaCodeFirstDb1` k�sm�n� istedi�iniz veritaban� ad�yla de�i�tirin. SQL Server �rne�inizin �al��t���ndan ve eri�ilebilir oldu�undan emin olun.

3.  **Varl�k Tan�mlar�:**

    -   **GameEntity (Oyun Varl���):**
        -   `Id` (int): Birincil anahtar.
        -   `Name` (string): Oyunun ad�.
        -   `Platform` (string): Oyunun mevcut oldu�u platform.
        -   `Rating` (decimal): Oyunun puan�, toplamda 3 basamak ve ondal�k k�s�mdan sonra 1 basamak hassasiyetle (�rne�in, 7.5).
    -   **MovieEntity (Film Varl���):**
        -   `Id` (int): Birincil anahtar.
        -   `Title` (string): Filmin ad�.
        -   `Genre` (string): Filmin t�r�.
        -   `ReleaseYear` (int): Filmin yay�n y�l�.

4.  **Veritaban� Olu�turma ve Migrasyonlar:**

    -   **Migrasyonlar� Ekleyin:**

        ```bash
        dotnet ef migrations add InitialCreate
        ```

    -   **Veritaban�n� G�ncelleyin:**

        ```bash
        dotnet ef database update
        ```

    -   Bu komutlar, kodunuzdaki varl�k tan�mlar�na g�re veritaban�n� ve tablolar� olu�turur.

5.  **Model Yap�land�rmas�:**

    -   `PatikaFirstDbContext.cs` dosyas�ndaki `OnModelCreating` metodu, modeli yap�land�rmak i�in kullan�l�r:
        -   `modelBuilder.Entity<MovieEntity>().ToTable("Movies");` ve `modelBuilder.Entity<GameEntity>().ToTable("Games");` varl�klar i�in tablo adlar�n� ayarlar.
        -   `modelBuilder.Entity<GameEntity>().Property(g => g.Rating).HasPrecision(3, 1);` `GameEntity`'nin `Rating` �zelli�inin hassasiyetini ve �l�e�ini yap�land�r�r.

## Kullan�m

Migrasyonlar� �al��t�rd�ktan sonra, `PatikaFirstDbContext`'i `Game` ve `Movie` varl�klar� �zerinde CRUD i�lemleri ger�ekle�tirmek i�in kullanabilirsiniz.

�rnek:

```csharp
using CodeFirstBasic.Context;
using CodeFirstBasic.Entities.Game;
using CodeFirstBasic.Entities.Movie;

// ...

using (var context = new PatikaFirstDbContext())
{
    // Yeni bir oyun ekle
    var newGame = new GameEntity { Name = "�rnek Oyun", Platform = "PC", Rating = 8.5m };
    context.Games.Add(newGame);
    context.SaveChanges();

    // Yeni bir film ekle
    var newMovie = new MovieEntity { Title = "�rnek Film", Genre = "Aksiyon", ReleaseYear = 2023 };
    context.Movies.Add(newMovie);
    context.SaveChanges();

    // Oyunlar� al
    var games = context.Games.ToList();

    // Filmleri al
    var movies = context.Movies.ToList();

    // ...
}