using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    /// <summary>
    /// Абстрактный класс строителя телефонных станций
    /// </summary>
    abstract public class TSBuildingCompany
    {
        /// <summary>
        /// Фабричный метод
        /// </summary>
        /// <returns></returns>
        abstract public TS BuildNew();
        /// <summary>
        /// Фабричный метод с параметрами
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="address">Адрес</param>
        /// <param name="userCount">Количество пользователей</param>
        /// <param name="price">Цена</param>
        /// <returns></returns>
        abstract public TS BuildNew(int id, string address, int userCount, double price);
    }
}
