using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_C_7._8
{
    internal class Program
    {
        /// <summary>
        /// Заголовки столбцов
        /// </summary>
        static void PrintNameColumns() 
        {
            Console.WriteLine();
            Console.WriteLine($"{"Id",5} {"Дата записи",20} {"Фамилия Имя Отчество",30} {"Возраст",7} {"Рост",4} {"Дата рождения",15} {"Место рождения",15}");
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод на экран всех работников
        /// </summary>
        static void GetAllWorkersNew()
        {
            Repository rp = new Repository();

            PrintNameColumns();

            Worker[] getAllWorkers = rp.GetAllWorkers();

            int allWorkerCount = getAllWorkers.Length;           

            for (int i = 0; i < allWorkerCount; i++)
            {
                getAllWorkers[i].Print();
            }
        }

        /// <summary>
        /// Вывод на экран работника по Id
        /// </summary>
        static void GetWorkerByIdNew(int id)
        {

            Repository rp = new Repository();

            Worker getWorkerById = rp.GetWorkerById(id);

            PrintNameColumns();

            if (getWorkerById.Id != 0)
            {
                getWorkerById.Print();
            }
            else
            {
                Console.WriteLine("Записи с таким id не существует.");
            }

        }

        /// <summary>
        /// Добавляем сотрудника
        /// </summary>
        static void AddWorkerNew()
        {
            // ФИО добавляемого сотрудника
            Console.Write("Введите ФИО сотрудника: ");
            string fio = Console.ReadLine();

            // Возраст сотрудника
            Console.Write("Введите возраст сотрудника: ");
            string age = Console.ReadLine();

            // Рост сотрудника
            Console.Write("Введите рост сотрудника: ");
            string height = Console.ReadLine();

            // Дата рождения сотрудника
            Console.Write("Введите дату рождения сотрудника: ");
            string dateBirth = Console.ReadLine();

            // Место рождения сотрудника
            Console.Write("Введите место рождения сотрудника: ");
            string placeBirth = Console.ReadLine();

            // Используем временный id
            Random rand = new Random();
            int id = rand.Next(10);

            DateTime dateRecord = DateTime.Now;

            Worker worker = new Worker(id, dateRecord, fio, age, height, dateBirth, placeBirth);

            Repository rp = new Repository();

            rp.AddWorker(worker);

            Console.WriteLine("Сотрудник добавлен.");
        }

        /// <summary>
        /// Удаление сотрудника по его id
        /// </summary>
        /// <param name="id"></param>
        static void DeleteWorkerNew(int id)
        {
            Repository rp = new Repository();

            rp.DeleteWorker(id);
        }

        /// <summary>
        /// Фильтрация сотрудников по диапазону дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        static void FilterWorkers(DateTime dateFrom, DateTime dateTo)
        {
            Repository rp = new Repository();            

            Worker[] worker = rp.GetWorkersBetweenTwoDates(dateFrom, dateTo);

            int count = worker.Length;

            for (int i = 0; i < count; i++)
            {
                worker[i].Print();
            }
        }

        /// <summary>
        /// Вывод на экран результата фильтрации сотрудников по диапазону дат
        /// </summary>
        static void GetWorkersBetweenTwoDatesNew() 
        {
            Console.Write("Введите первую дату в формате (дд.мм.гггг): ");
            string dateStringFrom = Console.ReadLine();

            Console.Write("Введите Вторую дату в формате (дд.мм.гггг): ");
            string dateStringTo = Console.ReadLine();

            DateTime dateFrom = DateTime.Parse(dateStringFrom);
            DateTime dateTo = DateTime.Parse(dateStringTo);

            PrintNameColumns();
            
            FilterWorkers(dateFrom, dateTo);
        } 

        static void Main(string[] args)
        {            
            string fileWorker = Repository.fileWorker;

            if (!File.Exists(fileWorker))
            {
                File.AppendAllText(fileWorker, "");
                Console.WriteLine("Создан новый файл. Добавьте сотрудников.");
                Console.ReadKey();                
            }

            bool indexСycle = true;

            do
            {
                Console.Clear();
                Console.Write("Выберите действие:\n" +
                                "1 - Вывести данные всех сотрудников на экран.\n" +
                                "2 - Вывести данные сотрудника по его id\n" +
                                "3 - Удалить сотрудника по его id\n" +
                                "4 - Добавить нового сотрудника\n" +
                                "5 - Фильтрация сотрудников по диапазону дат\n" +
                                "0 - Выход : ");
                byte indexData = Convert.ToByte(Console.ReadLine());

                switch (indexData)
                {
                    case 0:
                        indexСycle = false;
                        break;
                    case 1:
                        Console.Clear();
                        
                        GetAllWorkersNew();   
                        
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        
                        Console.Write("Для вывода информации о сотруднике введите его id: ");
                        int idInfo = Convert.ToInt32(Console.ReadLine());

                        GetWorkerByIdNew(idInfo);
                        
                        Console.ReadKey();
                        break;
                    case 3:    
                        Console.Clear();

                        Console.Write("Для удаления информации о сотруднике введите его id: ");
                        int idDel = Convert.ToInt32(Console.ReadLine());

                        DeleteWorkerNew(idDel); 

                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();

                        AddWorkerNew();

                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();

                        GetWorkersBetweenTwoDatesNew();

                        Console.ReadKey();
                        break;
                }
            } while (indexСycle);
        }
    }
}
