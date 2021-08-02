using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_BridgePattern
{
    class Program
    {
        /*
         Применимость
            Когда вы хотите разделить монолитный класс который содержит несколько различных реализаций
            какой то функциональности

            Когда класс нужно расширять в двух независимых плоскостях

            Когды вы хотите чтобы реализацию можно было изменять во время выполнения программы.

         */
        static void Main(string[] args)
        {
            IDevice tv = new TV();
            Remote remote = new Remote(tv);
            remote.TogglePower();

            IDevice radio = new Radio();
            AdvancedRemote advancedRemote = new AdvancedRemote(radio);
            advancedRemote.Mute();

            Console.ReadKey();
        }
    }
}
