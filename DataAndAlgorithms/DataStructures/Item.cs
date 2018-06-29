using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Item :IComparable<Item>
    {
        public int Weigth { get; set; }
        public int Value { get; set; }

        public float getSpecificValue()
        {
            return Value / Weigth;
        }

        public int CompareTo(Item item)
        {
            int result;
           
            if (this.getSpecificValue() > item.getSpecificValue())
            {
                result = 1;
            }
            else if (this.getSpecificValue() < item.getSpecificValue())
            {
                result = -1;
            }
            else {
                result = 0;
            }

            return result;
        }
    }
}
