using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_StrategyPattern
{
    class Context
    {
        private IStrategy strategy;

        public Context()
        {

        }

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void DoSomething()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");

            var result = strategy.DoAlgorithm(new List<String> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;

            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }
}
