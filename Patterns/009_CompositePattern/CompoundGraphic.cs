using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_CompositePattern
{
    /*
     Контейнер содержит операции добавления и удаления дочерних компонентов. 
        Все стандартные операции интерфейса компонентов он делегирует каждому из дочерних компонентов
     */
    public class CompoundGraphic : Graphic
    {
        protected List<Graphic> children = new List<Graphic>();

        public void Add(Graphic graphic)
        {
            children.Add(graphic);
        }

        public void Remove(Graphic graphic)
        {
            children.Remove(graphic);
        }

        public void Draw()
        {
            Console.WriteLine("Для каждого дочернего компонента нужно:\n" +
                "Отрисовать компонент и определить координаты максимальной вершины\n" +
                "Нарисовать пунктирную границу вокруг всей области");
        }

        public void Move(int x, int y)
        {
            foreach(Graphic child in children)
            {
                child.Move(x, y);
            }
        }
    }
}
