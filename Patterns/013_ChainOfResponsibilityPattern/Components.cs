using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_ChainOfResponsibilityPattern
{
    // Базовый класс простых компонентов
    abstract class Component : ComponentWithContextualHelp
    {
        public String ToolTipText { get; set; }

        // Контейнер содержащий компонент служит в качестве следующего звена цепочки
        public Container Container = null;

        // Базовое поведение компонента заключается в том чтобы показать всплывающую подсказку
        // если для нее создан текст. В обратном случае - перенаправить запрос своему контейнеру
        // если тот существует
        public virtual void ShowHelp()
        {
            if (ToolTipText != null)
                Console.WriteLine("Показать подсказку для базового компонента");
            else
                Container.ShowHelp();
        }
    }
}
