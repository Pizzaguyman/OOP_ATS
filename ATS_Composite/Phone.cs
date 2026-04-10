using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    public class Phone : ATSComponent
    {
        public override TreeNode Node { get; set; } = new TreeNode();
        public ulong Number { get; set; }
        public bool Busy { get; set; } = false;
        public Phone(ulong num, bool busy) : base()
        {
            Number = num;
            Busy = busy;
            Node.Text = $"{Number}, " + (Busy ? "занято" : "свободно");
        }
        public override void Add(ATSComponent c)
        {
            throw new NotImplementedException();
        }
        public override void Remove(ATSComponent c)
        {
            throw new NotImplementedException();
        }
        public override void Connect() => Busy = true;
        public override void Disconnect() => Busy = false;
    }
}
