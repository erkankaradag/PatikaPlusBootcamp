# Crazy Musicians API

Bu proje, hayali bir m�zisyenler listesini y�neten bir ASP.NET Core Web API uygulamas�d�r. Kullan�c�lar m�zisyenleri listeleyebilir, ekleyebilir, g�ncelleyebilir, silebilir ve arama yapabilir.

## Kullan�lan Teknolojiler
- **.NET Core 6+**
- **ASP.NET Core Web API**
- **C#**

## Ba�latma
Projeyi �al��t�rmak i�in a�a��daki ad�mlar� takip edebilirsiniz:

1. **Depoyu klonlay�n:**
   ```sh
   git clone https://github.com/kullaniciAdi/CrazyMusicians.git
   cd CrazyMusicians
   ```
2. **Gerekli ba��ml�l�klar� y�kleyin:**
   ```sh
   dotnet restore
   ```
3. **Projeyi �al��t�r�n:**
   ```sh
   dotnet run
   ```

## API Endpointleri

### 1. **T�m M�zisyenleri Getirme**
   **GET** `/api/musicians`
   
   Yan�t:
   ```json
   [
      {
         "id": 1,
         "name": "Amet �alg�",
         "profession": "�nl� �alg� �alar",
         "feature": "Her zaman yanl�� nota �alar, ama �ok e�lenceli"
      }
   ]
   ```

### 2. **Belirli Bir M�zisyeni Getirme**
   **GET** `/api/musicians/{id}`

### 3. **Yeni M�zisyen Ekleme**
   **POST** `/api/musicians`
   
   G�vde:
   ```json
   {
      "name": "Yeni M�zisyen",
      "profession": "Gitarist",
      "feature": "Harika solo atar"
   }
   ```

### 4. **M�zisyen Bilgilerini G�ncelleme**
   **PUT** `/api/musicians/{id}`
   
   G�vde:
   ```json
   {
      "name": "G�ncellenmi� �sim",
      "profession": "Yeni Meslek",
      "feature": "Yeni �zellik"
   }
   ```

### 5. **Sadece �zelli�i G�ncelleme**
   **PATCH** `/api/musicians/{id}`
   
   G�vde:
   ```json
   {
      "feature": "G�ncellenmi� �zellik"
   }
   ```

### 6. **M�zisyen Silme**
   **DELETE** `/api/musicians/{id}`

### 7. **M�zisyen Arama**
   **GET** `/api/musicians/search?search=melodi`
   
   Yan�t:
   ```json
   [
      {
         "id": 2,
         "name": "Zeynep Melodi",
         "profession": "Pop�ler Melodi Yazar�",
         "feature": "�ark�lar� yanl�� anla��l�r ama �ok pop�ler"
      }
   ]
   ```

## Katk�da Bulunma
E�er projeye katk�da bulunmak isterseniz, l�tfen �nce bir **pull request** a�arak de�i�iklik �nerilerinizi payla��n.

## Lisans
Bu proje MIT lisans� ile lisanslanm��t�r.

