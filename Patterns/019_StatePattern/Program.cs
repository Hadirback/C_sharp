using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_StatePattern
{
    /*
     Применимость
        Когда у вас есть объект поведение которого кардинально меняется в зщависимости от внутреннего состояния, причем типов
        состояний много и их код часто меняется.

        Когда код класса содержит множетво больших похожих друг на друга услованых операторов, котрые выбирают поведение в 
        зависимости от текущих значений полей класса.

        Когда вы сознательно используете табличную машину состояний построенную на условных операторах но вынуждены мириться
        с дублиролванием кода для похожих состояний и переходов.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();

            Console.ReadLine();
        }
    }
}
