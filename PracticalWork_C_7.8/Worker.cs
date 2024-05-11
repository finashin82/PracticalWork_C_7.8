using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_C_7._8
{
    /// <summary>
    /// Стуртура, описывающая рабочего
    /// </summary>
    struct Worker
    {
        #region Структура
        /// <summary>
        /// ID записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime DateRecord { get; set; }

        /// <summary>
        /// Фамилия, Имя, Отчество
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateBirth { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceBirth { get; set; }

        public void Print()
        {
            Console.WriteLine($"{this.Id,5} {this.DateRecord,20} {this.FIO,30} {this.Age,7} {this.Height,4} {this.DateBirth,15} {this.PlaceBirth,15}");
        }
        
        #endregion

        #region Создание сотрудника
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DateRecord"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="DateBirth"></param>
        /// <param name="PlaceBirth"></param>
        public Worker(int Id, DateTime DateRecord, string FIO, string Age, string Height, string DateBirth, string PlaceBirth)
        {
            this.Id = Id;
            this.DateRecord = DateRecord;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.DateBirth = DateBirth;
            this.PlaceBirth = PlaceBirth;
        }
        #endregion
        
        #region Конструктор
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="DateBirth"></param>
        /// <param name="PlaceBirth"></param>
        //public Worker(int Id, string DateRecord, string FIO, string Age, string Height, string DateBirth, string PlaceBirth) :
        //    this(Id, DateRecord, FIO, Age, Height, DateBirth, PlaceBirth)
        //{

        //}
        #endregion
    }
}
