using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    public class ManualTS : TS
    {
        Random rand = new Random();
        private static string[] RandomNames { get; set; } = ["Кирилл", "Елизавета", "Кира", "Олеся", "Андрей", "Милена", "Лариса", "Ульяна", "Олеся", "Люба"];
        public List<string> Employees { get; private set; } = [];
        public ManualTS() : base() { }
        public ManualTS(int id, string address, int userCount, double price) : base(id, address, userCount, price) { }
        public void AddEmployee() => Employees.Add(RandomNames[rand.Next(RandomNames.Length)]);
        public void AddEmployee(string name) => Employees.Add(name);
        public void RemoveEmployeeAt(int i) => Employees.RemoveAt(i);
    }
}
