using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManinulationTest
{
    class InheritanceTest
    {
        public static void Run()
        {
            A acom = new B();
            acom.CommonMeth();
        }
    }


    interface ICommon
    {
        void CommonMeth();
    }

    abstract class ACommon : ICommon
    {

        // Определение через abstarct
        /*
        public abstarct void CommonMeth();
        */

        public virtual void CommonMeth()
        {
            Console.WriteLine("Abstract Common Meth");
        }
    }

    class A : ACommon
    {
        public override void CommonMeth()
        {
            Console.WriteLine("A Class CommonMeth");
            base.CommonMeth();
        }
    }

    class B : A
    {
        public override void CommonMeth()
        {
            Console.WriteLine("B Class CommonMeth");
            base.CommonMeth();
        }
    }
}
