using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    public class AutomaticTS : TS
    {
        public int ComputerCount { get; set; } = 0;
        public AutomaticTS() : base() { }
        public AutomaticTS(int id, string address, int userCount, double price) : base(id, address, userCount, price) { }
        public void AddComputers(int count) => ComputerCount += count;
    }
}
