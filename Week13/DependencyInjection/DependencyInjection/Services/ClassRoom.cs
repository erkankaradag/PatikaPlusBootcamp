using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Service;

namespace DependencyInjection.Services
{
    internal class ClassRoom
    {
        private readonly ITeacher _teacher;

        // Constructor Injection
        public ClassRoom(ITeacher teacher)
        {
            _teacher = teacher;
        }

        public string GetTeacherInfo()
        {
            return _teacher.GetInfo();
        }
    }
}
