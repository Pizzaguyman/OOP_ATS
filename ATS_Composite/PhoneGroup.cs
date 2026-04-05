using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    public class PhoneGroup : ATSComponent
    {
        public string Name { get; set; } = "";
        List<ATSComponent> Components { get; set; } = new List<ATSComponent>();
        public int ComponentCount { get; private set; }
        public PhoneGroup(int id) : base(id) { Name = $"Id"; }
        public override void Add(ATSComponent c)
        {
            Components.Add(c);
            CountUpdate();
        }
        public override void Remove(int index)
        {
            Components.RemoveAt(index);
            CountUpdate();
        }
        private void CountUpdate()
        {
            foreach (ATSComponent c in Components)
            {
                if (c is PhoneGroup gr) ComponentCount += gr.ComponentCount;
                else ComponentCount++;
            }
        }
    }
}
