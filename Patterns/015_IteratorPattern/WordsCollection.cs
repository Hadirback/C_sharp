using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_IteratorPattern
{
    class WordsCollection : IteratorAggregate
    {
        List<String> collection = new List<string>();

        Boolean direction = false;

        public void ReverseDirection()
        {
            direction = !direction;
        }

        public List<String> GetItems()
        {
            return collection;
        }

        public void AddItem(string item)
        {
            collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, direction);
        }
    }
}
