using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ATS_Composite
{
    public class PhoneGroup : ATSComponent
    {
        public override TreeNode Node { get; set; } = new TreeNode();
        public string Name { get; set; } = "";
        List<ATSComponent> Components { get; set; } = new List<ATSComponent>();
        public int ComponentCount { get; private set; }
        public PhoneGroup() : base() { }
        public PhoneGroup(string name) : this() 
        { 
            Name = name;
            Node.Text = $"Группа {name}, {ComponentCount} компонентов";
        }
        public override void Add(ATSComponent c)
        {
            Components.Add(c);
            Node.Nodes.Add(c.Node);
            CountUpdate();
        }
        public override void Remove(ATSComponent c)
        {
            Node.Nodes.RemoveAt(Components.IndexOf(c));
            Components.Remove(c);
            CountUpdate();
        }
        private void CountUpdate()
        {
            ComponentCount = 0;
            foreach (ATSComponent c in Components)
            {
                if (c is PhoneGroup gr) ComponentCount += gr.ComponentCount;
                ComponentCount++;
            }
            Node.Text = $"Группа {Name}, {ComponentCount} компонентов";
        }
        public override void Connect()
        {
            foreach (ATSComponent c in Components) c.Connect();
        }
        public override void Disconnect()
        {
            foreach (ATSComponent c in Components) c.Disconnect();
        }
        public ATSComponent? FindChild(TreeNode node)
        {
            foreach(ATSComponent c in Components)
            {
                if(c.Node==node) return c;
            }
            foreach(ATSComponent c in Components)
            {
                if (c is PhoneGroup gr) return gr.FindChild(node);
            }
            return null;
        }
        public ATSComponent? FindParentOf(ATSComponent c)
        {
            if(this == c) return null;
            if (Components.Contains(c)) return this;
            foreach (ATSComponent ic in Components)
            {
                if (ic is PhoneGroup gr) return gr.FindParentOf(c);
            }
            return null;
        }
        public int GetBusiness()
        {
            int f = 0, t = 0;
            foreach (ATSComponent c in Components)
            {
                if (c is Phone ph)
                {
                    if (ph.Busy) t++;
                    else f++;
                }
                else if (c is PhoneGroup gr) gr.GetBusinessChild(ref f, ref t);
            }
            if (t == 0) return 0;
            else if (f == 0) return 2;
            else return 1;
        }
        private void GetBusinessChild(ref int f, ref int t)
        {
            foreach (ATSComponent c in Components)
            {
                if (c is Phone ph)
                {
                    if (ph.Busy) t++;
                    else f++;
                }
                else if (c is PhoneGroup gr) gr.GetBusinessChild(ref f, ref t);
            }
        }
        public void RemoveDeep(ATSComponent c)
        {
            FindParentOf(c)?.Remove(c);
        }
        public override string ToString()
        {
            return $"Группа {Name}, {ComponentCount} компонентов";
        }
    }
}
