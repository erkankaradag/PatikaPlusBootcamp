# Kütüphane Yönetim Sistemi

Bu proje, kitapları ve yazarları yönetmek için geliştirilmiş bir web uygulamasıdır. Kullanıcılar kitap ekleyebilir, düzenleyebilir, silebilir ve yazar bilgilerini yönetebilirler. Ayrıca, kullanıcı dostu bir arayüz ile kütüphane işlemlerini kolaylaştırır.

## Proje Özellikleri

*   **Kitap Yönetimi**: Kitap ekleme, güncelleme, silme, görüntüleme işlemleri.
*   **Yazar Yönetimi**: Yazar ekleme, güncelleme, silme, görüntüleme işlemleri.
*   **Hızlı Arama**: Kitap ve yazarları hızlıca arayarak kolayca erişim sağlama.
*   **Raporlama**: Kitap sayısı, yazar sayısı gibi raporların görüntülenmesi.
*   **Kullanıcı Dostu Arayüz**: Modern ve responsive bir tasarım.

## Kullanılan Teknolojiler

*   **ASP.NET Core MVC**: Web uygulamasının sunucu tarafı işleme ve veri yönetimi.
*   **C#**: Uygulamanın backend dili.
*   **Bootstrap 5**: Responsive tasarım için kullanılan CSS framework.
*   **SQL Server (veya PostgreSQL)**: Veritabanı yönetimi için kullanılabilir.
*   **Entity Framework Core**: Veritabanı ile etkileşim için ORM aracı.
*   **HTML, CSS, JavaScript**: Frontend geliştirme.
*   **Razor Pages**: Dinamik HTML sayfaları oluşturmak için.

## Başlangıç

1.  **Gereksinimler**

    Projeyi çalıştırabilmek için aşağıdaki araçlar ve yazılımlar gereklidir:

    *   .NET Core SDK (3.1 veya daha yeni bir sürüm)
    *   SQL Server veya PostgreSQL veritabanı
    *   Visual Studio veya Visual Studio Code (isteğe bağlı)
    *   Node.js ve npm (frontend için)

2.  **Kurulum**

    1.  Projeyi klonlayın: `git clone <proje_url>`
    2.  Veritabanını ayarlayın: `appsettings.json` dosyasında veritabanı bağlantı dizesini yapılandırın.
    3.  Gerekli NuGet paketlerini yükleyin: `dotnet restore`
    4.  Uygulamayı çalıştırın: `dotnet run`

## Uygulama Yapısı

1.  **Controllers**

    *   `BookController`: Kitaplarla ilgili işlemleri yönetir (ekleme, silme, güncelleme).
    *   `AuthorController`: Yazarlarla ilgili işlemleri yönetir.
    *   `HomeController`: Ana sayfa ve genel yönlendirmeler.

2.  **Models**

    *   `Book`: Kitap bilgilerini tutan model.
    *   `Author`: Yazar bilgilerini tutan model.
    *   `ApplicationUser`: Uygulama kullanıcıları için model (isteğe bağlı, kimlik doğrulama için).

3.  **Views**

    *   `Views/Book`: Kitap işlemleri için sayfalar (List, Create, Edit, Details).
    *   `Views/Author`: Yazar işlemleri için sayfalar.
    *   `Views/Home`: Ana sayfa ve hakkında sayfası.

4.  **Data**

    *   `ApplicationDbContext`: Veritabanı işlemlerini yöneten sınıf.

## Kullanıcı Arayüzü

Uygulama, Bootstrap 5 kullanılarak tasarlanmış olup, tamamen responsive (mobil uyumlu) bir arayüz sunmaktadır. Ana sayfa, kitaplar ve yazarlar için yönetim sayfaları, kullanıcı dostu bir arayüzle sunulmaktadır.

## Katkıda Bulunma

Projeye katkıda bulunmak isterseniz, lütfen bir "pull request" gönderin.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır.
