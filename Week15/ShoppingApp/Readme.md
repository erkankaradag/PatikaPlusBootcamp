# Online Alışveriş Platformu - Çok Katmanlı ASP.NET Core Web API Projesi

Bu proje, ASP.NET Core Web API kullanarak **Online Alışveriş Platformu** oluşturmak için geliştirilmiştir. Proje, **çok katmanlı mimari**yi takip ederek düzenli bir yapı sağlar ve aşağıdaki gereksinimleri karşılamaktadır:

- Entity Framework Code First yaklaşımı ile veritabanı etkileşimi
- Katmanlı mimari: Presentation Layer, Business Layer ve Data Access Layer
- Kimlik doğrulama ve yetkilendirme işlemleri için JWT kullanımı
- Veri güvenliği için şifrelerin **Data Protection** ile korunması
- Gelişmiş hata yönetimi ve loglama mekanizmaları
- Bakım modu ve model doğrulama kuralları

## Proje Yapısı

Proje 3 ana katmandan oluşmaktadır:

1. **Presentation Layer (API Katmanı)**: Controller'lar burada yer alır ve API'nin dış dünyayla etkileşimde bulunduğu yerdir.
2. **Business Layer (İş Katmanı)**: İş mantığı burada işlenir. Veritabanı işlemleri ve API talepleri arasında iş mantığını sağlar.
3. **Data Access Layer (Veri Erişim Katmanı)**: Entity Framework kullanarak veritabanı işlemleri burada gerçekleştirilir. Repository ve UnitOfWork desenleri ile veri erişimi sağlanır.

## Kullanılan Teknolojiler

- **ASP.NET Core 6.0**
- **Entity Framework Core** (Code First)
- **JWT (JSON Web Token)** ile Kimlik Doğrulama ve Yetkilendirme
- **ASP.NET Core Identity** (Custom veya hazır Identity Servisi)
- **Middleware** (İstek loglama, bakım modu)
- **Data Protection** (Şifre güvenliği)
- **Dependency Injection** (Bağımlılık yönetimi)

## Katmanlar

### 1. **Presentation Layer (API Katmanı)**

API'nin dış dünyayla etkileşimini sağlar. Burada, controller'lar yer alır ve çeşitli API endpoint'lerini sunar. Örnek olarak:

- **UserController**: Kullanıcı kayıt, giriş ve profil işlemleri.
- **ProductController**: Ürün listeleme, ürün ekleme ve güncelleme işlemleri.
- **OrderController**: Sipariş oluşturma, sipariş yönetimi.

### 2. **Business Layer (İş Katmanı)**

İş mantığının yer aldığı katmandır. Burada, servisler kullanılarak iş kuralları uygulanır. Örnek olarak:

- **UserManager**: Kullanıcı işlemleri, şifre güvenliği, rol yönetimi.
- **ProductManager**: Ürün işlemleri, stok yönetimi.
- **OrderManager**: Sipariş işlemleri, sipariş ürün yönetimi.

### 3. **Data Access Layer (Veri Erişim Katmanı)**

Veritabanı işlemleri burada yapılır. **Entity Framework Core** ile veri yönetimi sağlanır. Repository ve UnitOfWork desenleri kullanılarak veri erişimi yönetilir.

- **Repository<T>**: Veri erişimi işlemleri (CRUD işlemleri) için genel repository.
- **UnitOfWork**: İşlem birliği sağlar ve veritabanı işlemleri arasındaki ilişkiyi yönetir.
- **DbContext**: Entity Framework ile veritabanı etkileşimini sağlar.

## Veri Modelleri

Proje aşağıdaki temel veri modellerini kullanmaktadır:

### Kullanıcı (User)

- **Id** (int, anahtar)
- **FirstName** (string)
- **LastName** (string)
- **Email** (string, benzersiz)
- **PhoneNumber** (string)
- **Password** (string, şifrelenmiş)
- **Role** (Enum - Admin, Customer)

### Ürün (Product)

- **Id** (int, anahtar)
- **ProductName** (string)
- **Price** (decimal)
- **StockQuantity** (int)

### Sipariş (Order)

- **Id** (int, anahtar)
- **OrderDate** (DateTime)
- **TotalAmount** (decimal)
- **CustomerId** (int) - Müşteri ile ilişkilendirilmiş

### Sipariş Ürün (OrderProduct)

- **OrderId** (int)
- **ProductId** (int)
- **Quantity** (int)

## Kimlik Doğrulama ve Yetkilendirme

Projede **JWT (JSON Web Token)** kullanılarak kimlik doğrulama ve yetkilendirme işlemleri gerçekleştirilmiştir. Kullanıcılar giriş yaparak JWT token alabilir ve sistemdeki korumalı API'lere erişebilirler.

- Kullanıcılar **Admin** veya **Customer** rolüne sahip olabilir.
- JWT token'ları, kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini sağlar.

## Özellikler

- **Middleware**: Uygulama her isteği loglar. İstek URL'si, istek zamanı ve kullanıcı bilgileri kaydedilir.
- **Bakım Modu (Maintenance Mode)**: Eğer sistem bakımda ise, bakım modu aktif edilir ve gelen istekler yönlendirilir.
- **Action Filter**: API'lere belirli zaman dilimlerinde erişim izni verebilir.
- **Model Validation**: Kullanıcılar için e-posta formatı, zorunlu alanlar gibi doğrulama kuralları uygulanır.

## Data Protection

Kullanıcı şifreleri, **ASP.NET Core Data Protection** kullanılarak güvenli bir şekilde saklanır.

## Exception Handling

Tüm uygulama hataları, global exception handling middleware kullanılarak merkezi bir noktada yönetilir. Tüm hatalar loglanır ve kullanıcıya uygun bir mesaj döndürülür.

## Kurulum ve Çalıştırma

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/erkankaradag/ShoppingApp.git
cd ShoppingApp
