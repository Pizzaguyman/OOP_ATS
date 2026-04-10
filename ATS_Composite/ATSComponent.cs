using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    public abstract class ATSComponent
    {
        static public Dictionary<ATSComponent, TreeNode> Nodes { get; set; } = [];
        public abstract TreeNode Node { get; set; }
        public ATSComponent(){}
        public abstract void Add(ATSComponent c);
        public abstract void Remove(ATSComponent c);
        public abstract void Connect();
        public abstract void Disconnect();
    }
}
