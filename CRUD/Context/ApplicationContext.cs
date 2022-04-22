using CRUD.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Context
{
    /// <summary>
    /// Взаимодействие с базой данных в Entity Framework Core происходит посредством специального класса - контекста данных. 
    ///  DbContext определяет контекст данных, используемый для взаимодействия с базой данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// представляет набор объектов, которые хранятся в базе данных
        /// </summary>
        private DbSet<Student> Students => Set<Student>();

        public ApplicationContext() => Database.EnsureCreated();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder">устанавливает параметры подключения</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user id=root;persistsecurityinfo=True;database=students;password=0802");
        }

        /// <summary>
        /// Добавление нового студента в БД
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        public void Add(string firstName, string lastName, int age)
        {
            Student tom = new Student() { firstName = firstName, lastName = lastName, age = age };
            Students.Add(tom);
            SaveChanges();
        }

        /// <summary>
        /// Получение списка студентов
        /// </summary>
        /// <returns></returns>
        public Student[] Read()
        {
            return Students.ToArray<Student>();
        }

        /// <summary>
        /// Изменение студента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        public void Update(int id, string newFirstName, string newLastName, int newAge)
        {
            var student = Students.Find(id);
            student.age = newAge; student.firstName = newFirstName; student.lastName = newLastName;
            Update(student);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Remove(Students.Find(id));
            SaveChanges();
        }
    }
}
