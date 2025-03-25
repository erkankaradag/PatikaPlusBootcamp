# SurvivorAllStar Web API

## Proje Açıklaması
SurvivorAllStar, kategoriler ve yarışmacılar arasında bire-çok ilişki kuran, CRUD işlemleri yapabilen bir Web API projesidir.

## Kullanılan Teknolojiler
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **C#**
- **SQL Server**

## Proje Yapısı

### 1. **Context**
`SurvivorAllStarDbContext`: Veritabanı ile bağlantıyı sağlar ve `CategoryEntity`, `CompetitorEntity` tablolarını yönetir.

### 2. **Entity**
- `BaseEntity`: Ortak özellikleri (Id, CreatedDate, ModifiedDate, IsDeleted) içeren temel sınıf.
- `CategoryEntity`: Kategori bilgilerini tutar ve bağlı yarışmacıları içerir.
- `CompetitorEntity`: Yarışmacı bilgilerini tutar ve kategori ile ilişkilendirilir.

### 3. **Controllers**
- **CategoriesController**:
  - `GET api/categories` : Tüm kategorileri getirir.
  - `GET api/categories/{id}` : Belirli bir kategoriyi ve yarışmacılarını detaylı olarak getirir.
  - `POST api/categories` : Yeni bir kategori ekler.
  - `PUT api/categories/{id}` : Mevcut bir kategoriyi günceller.
  - `DELETE api/categories/{id}` : Kategoriyi siler (soft delete).

- **CompetitorsController**:
  - `GET api/competitors` : Tüm yarışmacıları getirir.
  - `GET api/competitors/{id}` : Belirli bir yarışmacının detaylarını getirir.
  - `GET api/competitors/categories/{categoryId}` : Belirli bir kategorideki yarışmacıları getirir.
  - `POST api/competitors` : Yeni bir yarışmacı ekler.
  - `PUT api/competitors/{id}` : Yarışmacı bilgilerini günceller.
  - `DELETE api/competitors/{id}` : Yarışmacıyı siler (soft delete).

### 4. **Models**
- **Categories**
  - `CategoryCreateRequest`: Yeni kategori oluşturma modeli.
  - `CategoryDetailResponse`: Kategori detaylarını döndüren model.
  - `CategoryListResponse`: Kategori listesini döndüren model.
  - `CategoryUpdateRequest`: Kategori güncelleme modeli.

- **Competitors**
  - `CompetitorAddRequest`: Yeni yarışmacı ekleme modeli.
  - `CompetitorDetailResponse`: Yarışmacı detaylarını döndüren model.
  - `CompetitorListResponse`: Yarışmacı listesini döndüren model.
  - `CompetitorsUpdateRequest`: Yarışmacı güncelleme modeli.

## Kurulum ve Çalıştırma

### 1. Bağımlılıkları yükleyin
```bash
 dotnet restore
```

### 2. Veritabanı bağlantısını ayarlayın
`appsettings.json` dosyasına bağlantı stringinizi ekleyin:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SurvivorAllStarDB;Trusted_Connection=True;"
}
```

### 3. Veritabanını oluşturun
```bash
 dotnet ef database update
```

### 4. API'yi çalıştırın
```bash
 dotnet run
```

### 5. API endpointlerini test edin
Swagger üzerinden API endpointlerini test edebilirsiniz: `https://localhost:5001/swagger`

## Geliştirme Notları
- `Soft Delete` yöntemi kullanılarak veriler fiziksel olarak silinmiyor, `IsDeleted` değeri `true` olarak işaretleniyor.
- `ForeignKey` ile kategori ve yarışmacılar arasında ilişki kuruldu.
- `Include()` ve `Where()` metodları ile veritabanı sorgu optimizasyonu sağlandı.

---
Eğer projeyi geliştirirken ek özellikler eklemek istersen veya performans iyileştirmeleri düşünüyorsan, birlikte kodu optimize edebiliriz 🚀!

