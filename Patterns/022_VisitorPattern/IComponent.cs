using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_VisitorPattern
{
    // Интерфейс компонента объявлет метод accept который в качестве аргумента может получать любой 
    // объект реализующий интерфейс посетителя.
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }
}
