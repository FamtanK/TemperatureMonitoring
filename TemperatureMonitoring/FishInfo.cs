using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace TemperatureMonitoring
{
	public class FishInfo
	{
		public string type;
		public int maxTemp;
		public int minTemp;
		public int maxTime;
		public int minTime;
		public DateTime beginTime;
		public List<int> temps;
		public List<Violation> violationsMax;
		public List<Violation> violationsMin;
		public int countViolationsMax;
		public int countViolationsMin;

		public FishInfo()
		{
			temps = new List<int>();
			violationsMax = new List<Violation>();
			violationsMin = new List<Violation>();
		}

		public string GetTemps()
        {
			string res = "";
			foreach (var temp in temps)
            {
				res += $"{temp} ";
            }
			return res;
        }

		public void FindViolations()
        {
			for (int i = 0; i < temps.Count; ++i)
            {
				if (temps[i] > maxTemp)
                {
					violationsMax.Add(new Violation(beginTime.AddMinutes((i + 1) * 10), temps[i], 
												 maxTemp, temps[i] - Math.Abs(maxTemp)));
					countViolationsMax++;
                }

				if (temps[i] < minTemp)
                {
					violationsMin.Add(new Violation(beginTime.AddMinutes((i + 1) * 10), temps[i],
												 minTemp, Math.Abs(minTemp) + temps[i]));
					countViolationsMin++;
				}
            }
        }

		public string GetViolations()
		{
			string res = "";
			if (countViolationsMax * 10 > maxTime)
			{
				res = $"Порог максимально допустимой температуры превышен на {countViolationsMax * 10 - maxTime} минут. \n";
			}
			foreach (var violation in violationsMax)
			{
				res += violation.ToString() + "\n";
			}

			if (countViolationsMin * 10 > minTime)
			{
				res += $"Порог минимально допустимой температуры превышен на {countViolationsMin * 10 - minTime} минут. \n";
			}
			foreach (var violation in violationsMin)
			{
				res += violation.ToString() + "\n";
			}
			return res;
        }
	}
}
