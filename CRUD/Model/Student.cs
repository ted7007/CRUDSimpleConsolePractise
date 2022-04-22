using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    /// <summary>
    /// Класс модели данных
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int age { get; set; }

    }
}
