using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movement
{
    public class Movement
    {
        public string type;
        public float value;
        public DateTime when;

        public int pointer(Movement[] myData, int lines)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < lines; i++)
            {
                if (myData[i].type == "B" && myData[i].when > myData[j].when)
                {
                    j = i;
                }
            }
            return j;
        }

        public float result(Movement[] myData, int lines)
        {
            float result = 0.0F;
            float sum = 0.0F;
            float cumulate = 0.0F;
            int diff;
            int i = 0;
            int j = 0;
            for (i = 0; i < lines; i++)
            {
                if (myData[i].type == "B" && myData[i].when > myData[j].when)
                {
                    j = i;
                }
            }
            for (i = 0; i < lines; i++)
            {
                if (myData[i].type == "D")
                {
                    diff = (myData[j].when - myData[i].when).Days;
                    sum = sum + myData[i].value;
                    cumulate = cumulate + diff * myData[i].value;
                }
            }
            result = (myData[j].value - sum) * 365.0F / cumulate;
            return result;
        }
    }
}