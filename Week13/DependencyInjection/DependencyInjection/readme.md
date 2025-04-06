# Dependency Injection Example

## 📌 Proje Açıklaması
Bu proje, **Dependency Injection (Bağımlılık Enjeksiyonu)** kavramını göstermek amacıyla hazırlanmıştır. Projede bir öğretmen ve sınıf modeli oluşturduk ve sınıfın öğretmene olan bağımlılığını **Constructor Injection** yöntemiyle dışarıdan sağladık.

---

## 🛠️ Kullanılan Teknolojiler
- C#
- .NET Core Console Application

---

## 📁 Klasör Yapısı
```
/DependencyInjectionExample
│
├── /Interfaces
│   └── ITeacher.cs
│
├── /Models
│   └── Teacher.cs
│
├── /Services
│   └── ClassRoom.cs
│
└── Program.cs
```

---

## 📌 Kod Yapısı

### 1️⃣ **Interfaces/ITeacher.cs**
```csharp
public interface ITeacher
{
    string GetInfo();
}
```
---

### 2️⃣ **Models/Teacher.cs**
```csharp
public class Teacher : ITeacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetInfo()
    {
        return $"Öğretmen: {FirstName} {LastName}";
    }
}
```
---

### 3️⃣ **Services/ClassRoom.cs**
```csharp
public class ClassRoom
{
    private readonly ITeacher _teacher;

    public ClassRoom(ITeacher teacher)
    {
        _teacher = teacher;
    }

    public string GetTeacherInfo()
    {
        return _teacher.GetInfo();
    }
}
```
---

### 4️⃣ **Program.cs**
```csharp
using Models;
using Services;
using Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        ITeacher teacher = new Teacher("Ahmet Yasin", "KARADAĞ");
        ClassRoom classRoom = new ClassRoom(teacher);

        Console.WriteLine(classRoom.GetTeacherInfo());
    }
}
```
---

## 🚀 Çalıştırma
Projeyi çalıştırmak için terminalde şu komutları takip et:

1. Projeyi oluştur:
   ```bash
   dotnet new console -n DependencyInjectionExample
   ```

2. Klasör yapısını oluştur:
   ```bash
   mkdir Interfaces Models Services
   ```

3. Kodları ilgili klasörlere yerleştir.

4. Projeyi çalıştır:
   ```bash
   dotnet run
   ```

✅ **Beklenen Çıktı:**
```
Öğretmen: Ahmet Yasin KARADAĞ
```

---

## 🎯 Kazanımlar
- **Interface kullanımı** sayesinde kod esnek ve genişletilebilir hale geldi.
- **Constructor Injection** ile sınıfların bağımlılıkları dışarıdan sağlanarak **loosely coupled** (gevşek bağlı) bir yapı elde edildi.
- Kod okunaklı ve sürdürülebilir bir hale getirildi.

---

💡 **İleri Seviye Geliştirmeler:**
- **Service Container** ekleyip, daha gelişmiş DI yapısı kurabiliriz.
- **Unit Test** ekleyerek, bağımlılıklardan bağımsız testler yazabiliriz.
- **Logger Service** gibi ek bağımlılıklar entegre edebiliriz.

