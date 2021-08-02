using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_ChainOfResponsibilityPattern
{
    // Контейнеры могут включать в себя как простые компоненты так и другие контейнеры
    // Здесь формируются связи цепочки. Класс контейнера унаследует метод showHelp
    // От своего родителя - базового компонента
    abstract class Container : Component
    {
        protected List<Component> children = new List<Component>();

        public void Add(Component component)
        {
            children.Add(component);
            component.Container = this;
        }
    }
}
