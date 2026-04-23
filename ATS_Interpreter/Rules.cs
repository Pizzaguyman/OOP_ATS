using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATS_Interpreter
{
    public class CheckWeekdays : IRuleElement
    {
        static readonly Dictionary<DayOfWeek, string> weekdayToString = new(){
            { DayOfWeek.Monday, "Понедельник"},
            {DayOfWeek.Tuesday,"Вторник"},
            {DayOfWeek.Wednesday, "Среда"},
            {DayOfWeek.Thursday, "Четверг"},
            {DayOfWeek.Friday, "Пятница"},
            {DayOfWeek.Saturday, "Суббота"},
            {DayOfWeek.Sunday, "Воскресенье"}
        };
        static readonly DayOfWeek[] weekdayArray = [
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
            ];
        List<DayOfWeek> weekdays = [];
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="indexes"></param>
        public CheckWeekdays(CheckedListBox.CheckedIndexCollection indexes)
        {
            foreach (int i in indexes) weekdays.Add(weekdayArray[i]);
        }
        /// <summary>
        /// Вычислить если данный звонок был сделан в разрешенный день недели
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
        public bool Interpret(CallContext c)
        {
            return weekdays.Contains(c.CallDateTime.DayOfWeek);
        }
        public override string ToString()
        {
            string str = "(";
            foreach(DayOfWeek day in weekdays)
            {
                str += weekdayToString[day];
                str += " или ";
            }
            str = str[..^5] + ")";
            return str;
        }
    }
    public class CheckDateRange : IRuleElement
    {
        public DateTime date1;
        public DateTime date2;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <exception cref="Exception"></exception>
        public CheckDateRange(DateTime d1, DateTime d2)
        {
            date1 = d1.Date;
            date2 = d2.Date;
            if (date1 > date2) throw new Exception();
        }
        /// <summary>
        /// Вычислить если данный звонок был сделан в разрешенный промежуток дней
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
        public bool Interpret(CallContext c)
        {
            return c.CallDateTime.Date>=date1 && c.CallDateTime.Date<=date2;
        }
        public override string ToString()
        {
            return $"(с {date1.ToString()[..^8]} до {date2.ToString()[..^8]})";
        }
    }
    public class CheckTimeRange : IRuleElement
    {
        public TimeSpan time1;
        public TimeSpan time2;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public CheckTimeRange(TimeSpan t1, TimeSpan t2)
        {
            time1 = t1;
            time2 = t2;
        }
        /// <summary>
        /// Вычислить если данный звонок был сделан в разрешенный промежуток времени дня
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
        public bool Interpret(CallContext c)
        {
            return time1 <= time2 ? c.CallDateTime.TimeOfDay >= time1 && c.CallDateTime.TimeOfDay <= time2 : 
                c.CallDateTime.TimeOfDay >= time1 || c.CallDateTime.TimeOfDay <= time2;
        }
        public override string ToString()
        {
            return $"(с {time1.ToString()[..^11]} до {time2.ToString()[..^11]})";
        }
    }
    public class CheckConnectionLength : IRuleElement
    {
        List<int> lengths = [];
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="indexes"></param>
        public CheckConnectionLength(CheckedListBox.CheckedIndexCollection indexes)
        {
            foreach (int i in indexes) lengths.Add(i);
        }
        /// <summary>
        /// Вычислить если данный звонок имеет разрешенную дальность 
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
        public bool Interpret(CallContext c)
        {
            return lengths.Contains(c.ConnectionLength);
        }
        public override string ToString()
        {
            string str = "(";
            foreach (int l in lengths)
            {
                str += CallContext.ConnectionLengthsArray[l];
                str += " или ";
            }
            str = str[..^5] + ")";
            return str;
        }
    }
    public class CheckHasMinutes : IRuleElement
    {
        bool AreMinutesRequired;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="req"></param>
        public CheckHasMinutes(bool req)
        {
            AreMinutesRequired = req;
        }
        /// <summary>
        /// Вычислить если у абонента есть минуты если они требуются
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
        public bool Interpret(CallContext c)
        {
            return c.HasMinutes || !AreMinutesRequired;
        }
        public override string ToString()
        {
            return AreMinutesRequired ? "Звонок тратит минуты" : "Звонок бесплатный";
        }
    }
}
