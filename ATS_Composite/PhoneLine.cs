using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    public class PhoneLine : ATSComponent
    {
        public int Caller1 { get; set; }
        public int Caller2 { get; set; }
        public bool Taken { get; private set; } = false;
        public PhoneLine(int id, int c1, int c2) : base(id)
        {
            if
        }
        public override void Add(ATSComponent c)
        {
            throw new NotImplementedException();
        }
        public override void Remove(int index)
        {
            throw new NotImplementedException();
        }
        public void Connect() => Taken = true;
        public void Disconnect() => Taken = false;
    }
}
