using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_IteratorPattern
{
    class AlphabeticalOrderIterator : Iterator
    {
        private WordsCollection collection;

        private int pos = -1;

        private bool reverse = false;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            this.collection = collection;
            this.reverse = reverse;

            if (reverse)
            {
                pos = collection.GetItems().Count;
            }
        }


        public override object Current()
        {
            return collection.GetItems()[pos];
        }

        public override int Key()
        {
            return pos;
        }

        public override bool MoveNext()
        {
            int updatePos = pos + (reverse ? -1 : 1);
            if(updatePos >= 0 && updatePos < collection.GetItems().Count)
            {
                pos = updatePos;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            pos = reverse ? collection.GetItems().Count - 1 : 0;
        }
    }
}
