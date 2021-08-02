using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_CompositePattern
{
    class Program
    {

        /*
         Применимость
            Когда вам нужно представить древовидную структуру объектов

            Когда клиенты должны единообразно трактовать простые и составные объекты
         */
        static CompoundGraphic all = new CompoundGraphic();

        static void Main(string[] args)
        {

            
            all.Add(new Dot(1, 2));
            all.Add(new Circle(5, 3, 10));
            CompoundGraphic second = new CompoundGraphic();
            second.Add(new Dot(2, 4));
            all.Add(second);

            groupSelected(new List<Graphic>
            {
                new Dot(1, 6),
                new Circle(6, 6, 6)
            });

            all.Move(2, 20);
            Console.ReadLine();
        }

        private static void groupSelected(List<Graphic> graphics)
        {
            CompoundGraphic group = new CompoundGraphic();
            foreach(Graphic graphic in graphics)
            {
                group.Add(graphic);
            }
            all.Add(group);
            all.Draw();
        }
    }
}
