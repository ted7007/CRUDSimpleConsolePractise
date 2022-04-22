using CRUD.Context;
using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.View
{
    class CRUDView
    {
        public void Start()
        {
            var isExit = false;
            while (!isExit)
            {
                Console.WriteLine("Введите команду: CREATE/READ/UPDATE/DELETE");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "CREATE":
                        // Добавление
                        Create();
                        
                        break;
                    case "READ":
                        Read();
                        
                        break;
                    case "UPDATE":
                        Update();
                        break;
                    case "DELETE":
                        Delete();
                        
                        break;
                }
            }
        }

        /// <summary>
        /// Процедура добавления нового студента в БД
        /// </summary>
        public void Create()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Console.WriteLine("Введите имя, фамилию и возраст нового студента через пробел.");
                    string[] data = Console.ReadLine().Split(' ');
                    Student tom = new Student { firstName = data[0], lastName = data[1], age = Int32.Parse(data[2]) };
                    // Добавление
                    db.Students.Add(tom);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Процедура вывода списка студентов
        /// </summary>
        public void Read()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    var list = db.Students.ToArray<Student>();
                    Console.WriteLine($"{"[Id]",4}{"[firstName]",20}{"[lastName]",20}{"[age]",5}");
                    foreach (var i in list)
                    {
                        Console.WriteLine($"{i.Id,4}{i.firstName,20}{i.lastName,20}{i.age,5}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Изменение студента в БД
        /// </summary>
        public void Update()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Console.WriteLine("Введите Id студента для редактирования");
                    var id = Console.ReadLine();
                    var user = db.Find(new Student().GetType(), Int32.Parse(id)) as Student;
                    if ((user is null))
                    {
                        Console.WriteLine("Студент не найден.");
                        return;
                    }
                    Console.WriteLine("Введите по очереди, через пробел новые данные - имя фамилию и возраст.");
                    string[] data = Console.ReadLine().Split(' ');
                    user.firstName = data[0]; user.lastName = data[1]; user.age = Int32.Parse(data[2]);
                    db.Update(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Процедура удаления студента из БД
        /// </summary>
        public void Delete()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    Console.WriteLine("Введите Id студента для удаления");
                    var id = Console.ReadLine();
                    db.Remove(db.Find(new Student().GetType(), Int32.Parse(id)));
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
