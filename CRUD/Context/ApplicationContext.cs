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
        public DbSet<Student> Students => Set<Student>();

        public ApplicationContext() => Database.EnsureCreated();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder">устанавливает параметры подключения</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user id=root;persistsecurityinfo=True;database=students;password=0802");
        }
    }
}
