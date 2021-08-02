using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_ChainOfResponsibilityPattern
{

    /*
     Применимость
        Когда программа должна обрабатывать разнообразные запросы несколькими способами,
        но заранее неизвестно, какие запросы будут приходить и какие обработчики для них понадобятся

        Когда важдно чтобы обработчики выполнялись один за другим в строгом порядке

        Когда набор объектов способных обработать запрос должен задаваться динамически
     */
    class Program
    {
        static void Main(string[] args)
        {
            Dialog d1 = new Dialog();
            d1.WikiPageURL = "HTTP://...";
            Panel p1 = new Panel();
            p1.ModelHelpText = "This panel does";
            Button ok = new Button();
            ok.ToolTipText = "This is Button";
            Button cancel = new Button();

            p1.Add(cancel);
            p1.Add(ok);
            d1.Add(p1);

            Console.ReadLine();
        }
    }
}
