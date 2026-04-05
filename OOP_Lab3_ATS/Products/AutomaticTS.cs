using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    /// <summary>
    /// Класс автоматической телефонной станции
    /// </summary>
    public class AutomaticTS : TS
    {
        public int ComputerCount { get; set; } = 0;
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AutomaticTS() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="address">Адрес</param>
        /// <param name="userCount">Количество пользователей</param>
        /// <param name="price">Цена</param>
        public AutomaticTS(int id, string address, int userCount, double price) : base(id, address, userCount, price) { }
        /// <summary>
        /// Добавить компьютеры АТС
        /// </summary>
        /// <param name="count">Количество добавляемых компьютеров</param>
        public void AddComputers(int count) => ComputerCount += count;
    }
}
