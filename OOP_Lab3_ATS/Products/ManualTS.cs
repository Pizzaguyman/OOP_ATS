using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    /// <summary>
    /// Класс ручной телефонной станции
    /// </summary>
    public class ManualTS : TS
    {
        Random rand = new Random();
        private static string[] RandomNames { get; set; } = ["Кирилл", "Елизавета", "Кира", "Олеся", "Андрей", "Милена", "Лариса", "Ульяна", "Олеся", "Люба"];
        public List<string> Employees { get; private set; } = [];
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ManualTS() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="address">Адрес</param>
        /// <param name="userCount">Количество пользователей</param>
        /// <param name="price">Цена</param>
        public ManualTS(int id, string address, int userCount, double price) : base(id, address, userCount, price) { }
        /// <summary>
        /// Добавить нового рабочего со случайным именем из RandomNames
        /// </summary>
        public void AddEmployee() => Employees.Add(RandomNames[rand.Next(RandomNames.Length)]);
        /// <summary>
        /// Добавить нового рабочего
        /// </summary>
        /// <param name="name">Имя рабочего</param>
        public void AddEmployee(string name) => Employees.Add(name);
        /// <summary>
        /// Удалить рабочего
        /// </summary>
        /// <param name="i">Индекс рабочего в списке</param>
        public void RemoveEmployeeAt(int i) => Employees.RemoveAt(i);
    }
}
