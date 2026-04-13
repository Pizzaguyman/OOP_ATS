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
        public DateTime CallDateTime { get; private set; }
        public int ConnectionDestination { get; private set; }
        public bool HasMinutes { get; private set; }
    }
}
