using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    public class ATSBuildingCompany : TSBuildingCompany
    {
        override public TS BuildNew()
        {
            return new AutomaticTS();
        }
        public override TS BuildNew(int id, string address, int userCount, double price)
        {
            return new AutomaticTS(id, address, userCount, price);
        }
    }
}
