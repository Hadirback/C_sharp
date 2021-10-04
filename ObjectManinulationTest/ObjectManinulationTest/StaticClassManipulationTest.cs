using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManinulationTest
{
    class StaticClassManipulationTest
    {
        public static void Run()
        {
            ConstructStaticClassTest.RunTest();
        }
    }


    public class ConstructClassTest
    {
        static ConstructClassTest()
        {
            Console.WriteLine("static");
        }

        public ConstructClassTest()
        {
            Console.WriteLine("ConstructClassTest");
        }

        public void RunTest()
        {
            Console.WriteLine("Run");
        }
    }

    public static class ConstructStaticClassTest
    {
        static ConstructStaticClassTest()
        {
            Console.WriteLine("static");
        }

        public static void RunTest()
        {
            Console.WriteLine("Run");
        }
    }
}
