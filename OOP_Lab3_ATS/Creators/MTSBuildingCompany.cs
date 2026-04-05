using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    /// <summary>
    /// Класс строителя ручных телефонных станций
    /// </summary>
    public class MTSBuildingCompany : TSBuildingCompany
    {
        /// <summary>
        /// Фабричный метод МТС
        /// </summary>
        /// <returns></returns>
        public override TS BuildNew()
        {
            return new ManualTS();
        }
        /// <summary>
        /// Фабричный метод МТС с параметрами
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="address">Адрес</param>
        /// <param name="userCount">Количество пользователей</param>
        /// <param name="price">Цена</param>
        /// <returns></returns>
        public override TS BuildNew(int id, string address, int userCount, double price)
        {
            return new ManualTS(id, address, userCount, price);
        }
    }
}
