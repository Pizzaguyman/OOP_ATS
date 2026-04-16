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
        //public readonly struct ConnectionLength
        //{
        //    static readonly int Citywide = 0;
        //    static readonly int Regionwide = 1;
        //    static readonly int Countrywide = 2;
        //    static readonly int International = 3;
        //}
        public static readonly string[] ConnectionLengthsArray = ["Городской", "Региональный", "Межрегиональный", "Интернациональный"];
        public DateTime CallDateTime { get; private set; }
        public int ConnectionLength { get; private set; }
        public bool HasMinutes { get; private set; }

        public CallContext(DateTime dt, int len, bool hasMins)
        {
            CallDateTime = dt;
            ConnectionLength = len;
            HasMinutes = hasMins;
        }
    }
}
