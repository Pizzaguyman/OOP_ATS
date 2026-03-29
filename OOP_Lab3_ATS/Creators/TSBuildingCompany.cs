using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3_ATS
{
    abstract public class TSBuildingCompany
    {
        abstract public TS BuildNew();
        abstract public TS BuildNew(int id, string address, int userCount, double price);
    }
}
