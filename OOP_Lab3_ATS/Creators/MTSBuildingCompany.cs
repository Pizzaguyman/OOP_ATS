using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    public class MTSBuildingCompany : TSBuildingCompany
    {
        public override TS BuildNew()
        {
            return new ManualTS();
        }
        public override TS BuildNew(int id, string address, int userCount, double price)
        {
            return new ManualTS(id, address, userCount, price);
        }
    }
}
