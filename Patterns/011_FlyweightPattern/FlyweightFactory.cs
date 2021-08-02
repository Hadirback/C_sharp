using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_FlyweightPattern
{
    public class FlyweightFactory
    {
        private List<(Flyweight, string)> flyweights = new List<(Flyweight, string)>();

        public FlyweightFactory(params Car[] args)
        {
            foreach (Car elem in args)
            {
                flyweights.Add((new Flyweight(elem), GetKey(elem)));
            }
        }

        // Возвращает хеш строки Легковеса для данного состояния.
        public string GetKey(Car key)
        {
            List<String> elemets = new List<string>();

            elemets.Add(key.Model);
            elemets.Add(key.Color);
            elemets.Add(key.Company);

            if(key.Owner != null && key.Number != null)
            {
                elemets.Add(key.Number);
                elemets.Add(key.Owner);
            }

            elemets.Sort();
            return string.Join("_", elemets);
        }

        // Возвращает существующий Легковес с заданным состоянием или создает
        // новый.
        public Flyweight GetFlyweight(Car sharedState)
        {
            string key = GetKey(sharedState);

            if(flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                flyweights.Add((new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void ListFlyweights()
        {
            var count = flyweights.Count;

            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }
}
