using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_C_7._8
{
    class Repository
    {
        public static string fileWorker = "Worker.txt";

        /// <summary>
        /// Вывод всех сотрудников на экран
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров           

            List<Worker> listWorker = new List<Worker>();

            // Открывает доступ к файлу для чтения данных
            using (StreamReader sr = new StreamReader(fileWorker, Encoding.Unicode))
            {
                string line;

                // Пока не пустая строка, выводим данные
                while ((line = sr.ReadLine()) != null)
                {
                    // Разбиваем строку в массив по #
                    string[] data = line.Split('#');

                    listWorker.Add(new Worker(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], data[3], data[4], data[5], data[6]));
                }

                sr.Close();
            }

            int count = listWorker.Count;

            Worker[] worker = new Worker[count];

            // Добавляем всех сотрудников в массив для вывода
            for (int i = 0; i < count; i++)
            {
                worker[i] = listWorker[i];
            }

            return worker;
        }

        /// <summary>
        /// Вывод на экран сотрудника по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID

            List<Worker> listWorker = new List<Worker>();

            // Открывает доступ к файлу для чтения данных
            using (StreamReader sr = new StreamReader(fileWorker, Encoding.Unicode))
            {
                string line;

                // Пока не пустая строка, выводим данные
                while ((line = sr.ReadLine()) != null)
                {
                    // Разбиваем строку в массив по #
                    string[] data = line.Split('#');

                    listWorker.Add(new Worker(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], data[3], data[4], data[5], data[6]));
                }

                sr.Close();
            }            

            int count = listWorker.Count;            

            int tempCount = 0;

            bool isExistenceId = false;

            // Находим нужный Id
            for (int i = 0; i < count; i++)
            {
                if (listWorker[i].Id == id)
                {
                    tempCount = i;
                    isExistenceId = true;
                    break;
                }
            }

            // Если id найден, выводим сотрудника
            if (isExistenceId)
            {
                return listWorker[tempCount];
            }
            else
            {
                return new Worker();
            }
        }

        /// <summary>
        /// Удаление сотрудника по его Id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого

            List<Worker> listWorker = new List<Worker>();

            // Открывает доступ к файлу для чтения данных
            using (StreamReader sr = new StreamReader(fileWorker, Encoding.Unicode))
            {
                string line;

                // Пока не пустая строка, выводим данные в список
                while ((line = sr.ReadLine()) != null)
                {
                    // Разбиваем строку в массив по #
                    string[] data = line.Split('#');

                    listWorker.Add(new Worker(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], data[3], data[4], data[5], data[6]));
                }

                sr.Close();
            }

            int count = listWorker.Count;
            
            int tempCount = 0;

            bool isExistenceId = false;

            // Находим нужный Id для удаления
            for (int i = 0; i < count; i++)
            {
                if (listWorker[i].Id == id)
                {
                    tempCount = i;
                    isExistenceId = true;
                    break;
                }               
            }

            // Если id найден, удаляем его из списка и перезаписываем файл
            if (isExistenceId)
            {
                listWorker.RemoveAt(tempCount);

                int countNew = listWorker.Count;
                
                // Перезаписываем файл
                using (FileStream fs = new FileStream(fileWorker, FileMode.Truncate))
                {
                    // Запись в новый файл
                    StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                    for (int i = 0; i < countNew; i++)
                    {
                        string note = String.Join("#", Convert.ToString(listWorker[i].Id), Convert.ToString(listWorker[i].DateRecord), 
                            Convert.ToString(listWorker[i].FIO), Convert.ToString(listWorker[i].Age),
                            Convert.ToString(listWorker[i].Height), Convert.ToString(listWorker[i].DateBirth), Convert.ToString(listWorker[i].PlaceBirth));

                        sw.WriteLine(note);
                    }

                    sw.Close();
                    fs.Close();
                }
                Console.WriteLine();
                Console.WriteLine("Сотрудник удален.");
            }
            else
            {
                Console.WriteLine("Записи с таким Id не существует.");
            }
        }

        /// <summary>
        /// Добавляем сотрудника
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл

            List<Worker> listWorker = new List<Worker>();

            // Открывает доступ к файлу для чтения данных
            using (StreamReader sr = new StreamReader(fileWorker, Encoding.Unicode))
            {
                string line;

                // Пока не пустая строка, выводим данные
                while ((line = sr.ReadLine()) != null)
                {
                    // Разбиваем строку в массив по #
                    string[] data = line.Split('#');

                    listWorker.Add(new Worker(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], data[3], data[4], data[5], data[6]));
                }

                sr.Close();
            }

            int count = listWorker.Count;

            // Если в файле есть записи, то увеличиваем id последнего worker на 1, если нет то запись будет первая
            if (count != 0)
            {
                worker.Id = listWorker[count - 1].Id + 1;
            }
            else
            {
                worker.Id = 1;
            }

            // Добавляем сотрудника в файл
            StreamWriter swAdd = new StreamWriter(fileWorker, true, Encoding.Unicode);
            {
                string note = String.Join("#", Convert.ToString(worker.Id), Convert.ToString(worker.DateRecord),
                    Convert.ToString(worker.FIO), Convert.ToString(worker.Age),
                    Convert.ToString(worker.Height), Convert.ToString(worker.DateBirth), Convert.ToString(worker.PlaceBirth));

                swAdd.WriteLine(note);
            }

            swAdd.Close();
        }

        /// <summary>
        /// Вывод списка сотрудников по диапазону дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров

            List<Worker> listWorker = new List<Worker>();

            // Открывает доступ к файлу для чтения данных
            using (StreamReader sr = new StreamReader(fileWorker, Encoding.Unicode))
            {
                string line;

                // Пока не пустая строка, выводим данные
                while ((line = sr.ReadLine()) != null)
                {
                    // Разбиваем строку в массив по #
                    string[] data = line.Split('#');

                    listWorker.Add(new Worker(Convert.ToInt32(data[0]), Convert.ToDateTime(data[1]), data[2], data[3], data[4], data[5], data[6]));
                }

                sr.Close();
            }

            int count = listWorker.Count;
           
            List<Worker> workerList = new List<Worker>();

            int countList = 0;

            // Выбираем сотрудников удовлетворяющих условиям
            for (int i = 0; i < count; i++) 
            {
                if (dateFrom <= listWorker[i].DateRecord && dateTo >= listWorker[i].DateRecord)
                {                    
                   workerList.Add(listWorker[i]);
                    countList++;                   
                }
            }

            int countWorker = workerList.Count;

            Worker[] worker = new Worker[countWorker];

            // Составляем список для вывода
            for (int i = 0; i < countWorker; i++)
            {
                worker[i] = workerList[i];
            }

            return worker;
        }
    }
}
