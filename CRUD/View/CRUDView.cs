using CRUD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.View
{
    public class CRUDView
    {
        #region fields

        ApplicationContext dataBase;



        #endregion
        public void Start()
        {
            using (dataBase = new ApplicationContext())
            {
                var isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("Введите команду: CREATE/READ/UPDATE/DELETE");
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "CREATE":
                            Console.WriteLine("Введите имя, фамилию и возраст нового студента через пробел.");
                            Create(Console.ReadLine());

                            break;
                        case "READ":
                            Read();

                            break;
                        case "UPDATE":
                            Console.WriteLine("Введите по очереди, через пробел id студента, данные которые следует изменить\n" +
                                          "Затем новые данные - имя фамилию и возраст.");
                            Update(Console.ReadLine());
                            break;
                        case "DELETE":
                            Console.WriteLine("Введите Id студента для удаления");
                            Delete(Console.ReadLine());
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Процедура добавления нового студента в БД
        /// </summary>
        public void Create(string answer)
        {
            try
            {
                var data = ParseToData(answer);
                dataBase.Add(data[1], data[2], Int32.Parse(data[3]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Процедура вывода списка студентов
        /// </summary>
        public void Read()
        {
            try
            {
                var list = dataBase.Read();
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

        /// <summary>
        /// Изменение студента в БД
        /// </summary>
        public void Update(string answer)
        {
            try
            {
                var data = ParseToData(answer);
                dataBase.Update(Int32.Parse(data[0]), data[1], data[2], Int32.Parse(data[3]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Процедура удаления студента из БД
        /// </summary>
        public void Delete(string answer)
        {
            try
            {
                var id = Int32.Parse(ParseToData(answer)[0]);
                dataBase.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Метод парса входных данных в данные студента
        /// </summary>
        /// <param name="lineWithData">Входные параметры вида "id firstname lastname age" </param>
        /// <returns>Массив данных, где data[0] - id, data[1] - firstname, data[2] - lastname, data[3] - age</returns>
        public string[] ParseToData(string lineWithData)
        {
            // 3 варианта: 1 - data содержит только id. 2 - Дата содержит только fName, lName, age. 3 - Дата содержит и 
            string[] data = lineWithData.Split(' ');
            int res = -1;
            switch (data.Length)
            {
                case 1:
                    if (!Int32.TryParse(data[0], out res))
                        throw new ArgumentException("data[0] isn't id");
                    break;
                case 3:
                    if (!Int32.TryParse(data[2], out res))
                        throw new ArgumentException("lineWithData");
                    var result = new string[4];
                    result[1] = data[0];
                    result[2] = data[1];
                    result[3] = data[2];
                    return result;
                    break;
                case 4:
                    if (!Int32.TryParse(data[0], out res) || !(Int32.TryParse(data[3], out res)))
                        throw new ArgumentException("lineWithData");
                    break;
                default:
                    throw new ArgumentException("lineWithData");
            }
            return data;
        }
    }
}
