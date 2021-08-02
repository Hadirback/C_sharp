using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_FacadePattern
{
    /*
     Класс фасада предоставляет простой интерфейс для сложной логики одной или 
    несколькиз подсистем. Фасад делегирует запросы клиентов соответствующим объектам
    внутри подсистемы. Фаса таже отвечает за управление их жизненным циклом. Все это
    защищает клиента от нежелательной сложности подсистемы.
     */
    public class Facade
    {

        protected Subsystem1 subsystem1;
        protected Subsystem2 subsystem2;

        public Facade(Subsystem1 s1, Subsystem2 s2)
        {
            subsystem1 = s1;
            subsystem2 = s2;
        }


        /*
         Методы фасада удобны для быстрого доступа к сложной функциональности подсистем. 
        Однако клиенты получают только часть возможностей подсистемы
         */
        public String Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this.subsystem1.Operation1();
            result += this.subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this.subsystem1.OperationN();
            result += this.subsystem2.OperationZ();
            return result;
        }
    }
}
