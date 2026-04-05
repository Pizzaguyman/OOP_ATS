using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    public abstract class ATSComponent
    {
        static private HashSet<int> IdSet { get; set; } = new HashSet<int>();
        public int Id { get; private set; }
        public ATSComponent(int id)
        {
            if (IdSet.Add(id)) Id = id;
            else throw new ArgumentException("Id taken");
        }
        public abstract void Add(ATSComponent c);
        public abstract void Remove(int index);
    }
}
