using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Interpreter
{
    /// <summary>
    /// Класс контекста звонка
    /// </summary>
    public class CallContext
    {
        /// <summary>
        /// Соответствие дальностей звонка с целочисленными значениями
        /// </summary>
        public static readonly string[] ConnectionLengthsArray = ["Городской", "Региональный", "Межрегиональный", "Интернациональный"];
        /// <summary>
        /// Момент звонка
        /// </summary>
        public DateTime CallDateTime { get; private set; }
        /// <summary>
        /// Целое число от 0 до 3, соответствующее дальности звонка
        /// </summary>
        public int ConnectionLength { get; private set; }
        /// <summary>
        /// У звонящего абонента есть тарифные минуты
        /// </summary>
        public bool HasMinutes { get; private set; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="dt">Момент звонка</param>
        /// <param name="len">Индекс дальности звонка</param>
        /// <param name="hasMins">Есть ли у абонента минуты</param>
        public CallContext(DateTime dt, int len, bool hasMins)
        {
            CallDateTime = dt;
            ConnectionLength = len;
            HasMinutes = hasMins;
        }
    }
}
