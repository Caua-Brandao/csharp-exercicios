using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercice.Services
{
    internal class CalculationService
    {
        public static  T Max<T>(List<T> list) where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                throw new Exception("List is empty");
            }
            T max = list[0];
            for (int i = 1;i<list.Count;i++)
            {
                if (max.CompareTo(list[i]) <0) 
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}
