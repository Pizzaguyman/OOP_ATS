using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    /// <summary>
    /// Класс компонент телефонного номера
    /// </summary>
    public class Phone : ATSComponent
    {
        /// <summary>
        /// Узел TreeList, с которым связан компонент
        /// </summary>
        public override TreeNode Node { get; set; } = new TreeNode();
        public ulong Number { get; set; }
        public bool Busy { get; set; } = false;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="num">Номер телефона</param>
        /// <param name="busy">Занятость номера</param>
        public Phone(ulong num, bool busy) : base()
        {
            Number = num;
            Busy = busy;
            Node.Text = ToString();
        }
        /// <summary>
        /// Добавление не имплементируется для компонента без подкомпонентов
        /// </summary>
        /// <param name="c"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Add(ATSComponent c)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавление не имплементируется для компонента без подкомпонентов
        /// </summary>
        /// <param name="c"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Remove(ATSComponent c)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Сделать телефонный номер занятым
        /// </summary>
        public override void Connect() => Busy = true;
        /// <summary>
        /// Сделать телефонный номер свободным
        /// </summary>
        public override void Disconnect() => Busy = false;
        /// <summary>
        /// Получить информацию об объекте в строке
        /// </summary>
        /// <returns>Описание объекта телефонной группы</returns>
        public override string ToString()
        {
            return $"{Number}, " + (Busy ? "занято" : "свободно");
        }
    }
}
