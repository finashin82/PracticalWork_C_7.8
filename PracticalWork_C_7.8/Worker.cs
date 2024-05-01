using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_C_7._8
{
    struct Worker
    {
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

        /// <summary>
        /// Печать
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return ($"ID: {Id} Дата записи: {DateRecord} ФИО: {FIO} Возраст: {Age} Рост: {Height} Дата рождения {DateBirth} Место рождения: {PlaceBirth}");
        }
    }
}
