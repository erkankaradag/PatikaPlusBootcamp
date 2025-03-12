# CodeFirstRelation Projesi

## Proje Açıklaması
Bu proje, Entity Framework Core kullanarak Code First yaklaşımı ile bir kullanıcı ve gönderi (User - Post) ilişkisi oluşturmaktadır. Kullanıcılar ve gönderiler arasında bire çok (One-to-Many) bir ilişki bulunmaktadır.

## Kullanılan Teknolojiler
- .NET Core
- Entity Framework Core
- SQL Server

## Veritabanı Yapısı
### Kullanıcılar (Users) Tablosu
- **Id**: Kullanıcı kimliği (Primary Key, Otomatik Artan)
- **UserName**: Kullanıcı adı
- **Email**: Kullanıcı e-posta adresi

### Gönderiler (Posts) Tablosu
- **Id**: Gönderi kimliği (Primary Key, Otomatik Artan)
- **Title**: Gönderi başlığı
- **Content**: Gönderi içeriği
- **UserId**: Kullanıcı kimliği (Foreign Key, Kullanıcı tablosu ile ilişkilendirilir)

## Migration Komutları

### 1. Migration Oluşturma
```bash
 dotnet ef migrations add InitialCreate
```

### 2. Veritabanını Güncelleme
```bash
 dotnet ef database update
```

## Proje Kurulumu

1. **Proje deposunu klonlayın:**
    ```bash
    git clone <repository_url>
    ```

2. **Bağımlılıkları yükleyin:**
    ```bash
    dotnet restore
    ```

3. **Veritabanını oluşturun:**
    ```bash
    dotnet ef database update
    ```

4. **Uygulamayı çalıştırın:**
    ```bash
    dotnet run
    ```

## İlişki Yapısı
Bir Kullanıcı (User) birden fazla Gönderi (Post) yazabilir. Bu ilişki aşağıdaki şekilde modellenmiştir:

```
User (1) ----- (n) Post
```

## Katkıda Bulunma
Proje geliştirilmesine katkı sağlamak isteyenler için:
- Fork'layın
- Yeni bir branch oluşturun (`git checkout -b feature/yeniozellik`)
- Değişikliklerinizi commit edin (`git commit -m 'Yeni özellik eklendi'`)
- Push'layın (`git push origin feature/yeniozellik`)
- Pull Request açın

## Lisans
MIT Lisansı ile sunulmuştur.

---
Happy coding! 🚀

