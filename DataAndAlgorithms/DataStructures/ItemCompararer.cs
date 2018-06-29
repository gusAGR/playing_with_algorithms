using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class ItemComparerBySpecificValue : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            int result;

            if (x.getSpecificValue() > y.getSpecificValue())
            {
                result = 1;
            }
            else if (x.getSpecificValue() < y.getSpecificValue())
            {
                result = -1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
