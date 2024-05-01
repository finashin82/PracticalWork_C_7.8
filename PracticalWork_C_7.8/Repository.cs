using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_C_7._8
{
    class Repository
    {
        // Имя файла
        string nameFileWorker = "Worker.csv";

        public Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров

            

            // Проверяем файл на существование и если он существует, то выводим данные
            if (File.Exists(nameFileWorker))
            {
                // Открывает доступ к файлу для чтения данных
                using (StreamReader sr = new StreamReader("Worker.txt", Encoding.Unicode))
                {
                    Console.WriteLine();

                    Console.WriteLine();

                    Console.WriteLine();
                    string line;

                    // Пока не пустая строка, выводим данные
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Разбиваем строку в массив по #
                        string[] data = line.Split('#');
                        Console.WriteLine($"{data[0],5} * {data[1],11} * {data[2],30} * {data[3],7} * " +
                                            $"{data[4],4} * {data[5],13} * {data[6],15}");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("Файл не найден.");
        }

        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
        }
    }
}
