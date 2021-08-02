using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_ChainOfResponsibilityPattern
{
    class Panel : Container
    {
        public String ModelHelpText { get; set; }

        public override void ShowHelp()
        {
            if (ModelHelpText != null)
            {
                Console.WriteLine("Показать модальное окно для панели");
            }
            else
                base.ShowHelp();
        }
    }

    class Dialog : Container
    {
        public String WikiPageURL { get; set; }

        public override void ShowHelp()
        {
            if(WikiPageURL != null)
                Console.WriteLine("Открыть страницу ВИКИ в браузере");
            else
                base.ShowHelp();
        }
    }
}
