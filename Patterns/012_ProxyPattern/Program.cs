using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ProxyPattern
{
    class Program
    {
        /*
         Применимость

            Ленивая инициализация - виртуальный прокси. Когда у вас есть тяжелый объект, грузящий 
            данные из файловой системы или БД

            Защита доступа - защищающий прокси. Когда в программе есть разщные типы пользователей
            и вам хочется защищать объект от неавторизированного доступа. Например если ваши
            объекта это важная часть операционной системы а пользователи сторонние программы.

            Локальный запуск сервиса - удаленный проски. Когда настоящий сервисный объект находится
            на удаленном сервере

            Логирование запросов - логирующий прокси. Когда требуется хранить историю обращений
            к сервисному объекту

            Кэширование объектов - умная ссылка. Когда нужно кэшировать результаты запросов клиентов
            и управлять их жизненным циклом
         */
        static void Main(string[] args)
        {
            ThirdPartyYouTubeClass youtubeSerive = new ThirdPartyYouTubeClass();
            IThirdPartyYouTubeLib youtubeProxy = new CashedYouTubeClass(youtubeSerive);
            YouTubeManager youTubeManager = new YouTubeManager(youtubeProxy);
            youTubeManager.ReactOnUserInput();

            Console.ReadKey();
        }
    }
}
