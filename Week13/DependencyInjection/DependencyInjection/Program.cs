using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Manager;
using DependencyInjection.Serives;
using DependencyInjection.Service;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dependency Injection ile Teacher sınıfı örneğini ClassRoom'a enjekte ediyoruz
            ITeacher teacher = new Teacher("Ahmet Yasin", "Karadağ");
            ClassRoom classRoom = new ClassRoom(teacher);

            // Çıktıyı ekrana yazdır
            Console.WriteLine(classRoom.GetTeacherInfo());
        }
    }
}
