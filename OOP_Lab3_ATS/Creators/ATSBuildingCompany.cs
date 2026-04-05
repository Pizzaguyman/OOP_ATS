using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    /// <summary>
    /// Класс строителя автоматических телефонных станций
    /// </summary>
    public class ATSBuildingCompany : TSBuildingCompany
    {
        /// <summary>
        /// Фабричный метод АТС
        /// </summary>
        /// <returns></returns>
        override public TS BuildNew()
        {
            return new AutomaticTS();
        }
        /// <summary>
        /// Фабричный метод АТС с параметрами
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="address">Адрес</param>
        /// <param name="userCount">Количество пользователей</param>
        /// <param name="price">Цена</param>
        /// <returns></returns>
        public override TS BuildNew(int id, string address, int userCount, double price)
        {
            return new AutomaticTS(id, address, userCount, price);
        }
    }
}
