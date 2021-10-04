using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManinulationTest
{
    class ListRefTest
    {

        public static void Run()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            IEnumerable<int> items = list.Select(i => i + 2);
            for (int i = 0; i < list.Count; i++)
                list[i] = 0;

            foreach (var item in items)
            {
                Console.Write(item);
            }
        }
    }
}
