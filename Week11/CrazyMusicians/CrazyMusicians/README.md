# Crazy Musicians API

Bu proje, hayali bir müzisyenler listesini yöneten bir ASP.NET Core Web API uygulamasýdýr. Kullanýcýlar müzisyenleri listeleyebilir, ekleyebilir, güncelleyebilir, silebilir ve arama yapabilir.

## Kullanýlan Teknolojiler
- **.NET Core 6+**
- **ASP.NET Core Web API**
- **C#**

## Baþlatma
Projeyi çalýþtýrmak için aþaðýdaki adýmlarý takip edebilirsiniz:

1. **Depoyu klonlayýn:**
   ```sh
   git clone https://github.com/kullaniciAdi/CrazyMusicians.git
   cd CrazyMusicians
   ```
2. **Gerekli baðýmlýlýklarý yükleyin:**
   ```sh
   dotnet restore
   ```
3. **Projeyi çalýþtýrýn:**
   ```sh
   dotnet run
   ```

## API Endpointleri

### 1. **Tüm Müzisyenleri Getirme**
   **GET** `/api/musicians`
   
   Yanýt:
   ```json
   [
      {
         "id": 1,
         "name": "Amet Çalgý",
         "profession": "Ünlü Çalgý Çalar",
         "feature": "Her zaman yanlýþ nota çalar, ama çok eðlenceli"
      }
   ]
   ```

### 2. **Belirli Bir Müzisyeni Getirme**
   **GET** `/api/musicians/{id}`

### 3. **Yeni Müzisyen Ekleme**
   **POST** `/api/musicians`
   
   Gövde:
   ```json
   {
      "name": "Yeni Müzisyen",
      "profession": "Gitarist",
      "feature": "Harika solo atar"
   }
   ```

### 4. **Müzisyen Bilgilerini Güncelleme**
   **PUT** `/api/musicians/{id}`
   
   Gövde:
   ```json
   {
      "name": "Güncellenmiþ Ýsim",
      "profession": "Yeni Meslek",
      "feature": "Yeni özellik"
   }
   ```

### 5. **Sadece Özelliði Güncelleme**
   **PATCH** `/api/musicians/{id}`
   
   Gövde:
   ```json
   {
      "feature": "Güncellenmiþ özellik"
   }
   ```

### 6. **Müzisyen Silme**
   **DELETE** `/api/musicians/{id}`

### 7. **Müzisyen Arama**
   **GET** `/api/musicians/search?search=melodi`
   
   Yanýt:
   ```json
   [
      {
         "id": 2,
         "name": "Zeynep Melodi",
         "profession": "Popüler Melodi Yazarý",
         "feature": "Þarkýlarý yanlýþ anlaþýlýr ama çok popüler"
      }
   ]
   ```

## Katkýda Bulunma
Eðer projeye katkýda bulunmak isterseniz, lütfen önce bir **pull request** açarak deðiþiklik önerilerinizi paylaþýn.

## Lisans
Bu proje MIT lisansý ile lisanslanmýþtýr.

