using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_AdapterPattern
{
    class Program
    {
        /*
         Применимость
            Когда вы хотите использовать сторонний класс но его интерфейс не соответствует
            остальному коду приложения

            Когда вам нужно использовать несколько существующих подклассов но в них не хватает
            какой то общей функциональности причем расширить суперкласс вы не можете.
         */
        static void Main(string[] args)
        {

            RoundHole hole = new RoundHole(5);
            RoundPeg rPeg = new RoundPeg(5);

            Console.WriteLine(hole.Fits(rPeg)); 

            SquarePeg smallSPeg = new SquarePeg(5);
            SquarePeg largeSPeg = new SquarePeg(10);


            SquarePegAdapter smallSPegAdapter = new SquarePegAdapter(smallSPeg);
            SquarePegAdapter largeSPegAdapter = new SquarePegAdapter(largeSPeg);
            Console.WriteLine(hole.Fits(smallSPegAdapter));
            Console.WriteLine(hole.Fits(largeSPegAdapter));

            Console.ReadLine();
        }
    }
}
