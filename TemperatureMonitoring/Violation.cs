using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitoring
{
    public class Violation
    {
        DateTime time;
        int res;
        int standart;
        int difference;

        public Violation(DateTime time, int res, int standart, int difference)
        {
            this.time = time;
            this.res = res;
            this.standart = standart;
            this.difference = difference;
        }

        public override string ToString()
        {
            return $"{time}   {res}   {standart}   {difference}";
        }
    }
}
