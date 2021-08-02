using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kthLargestElement
{
    class Program
    {
        public class MinHeap
        {
            int[] harr;
            int heap_size;
            int left(int i) { return ((2 * i) + 1); }
            int right(int i) { return ((2 * i) + 2); }
            public int getMin() { return harr[0]; }

            public MinHeap(int[] a, int size)
            {
                heap_size = size;
                harr = a;

                int i = (heap_size - 1) / 2;

                while( i >= 0)
                {
                    minHeapify(i);
                    i--;
                }
            }

            public int extractMin()
            {
                if(heap_size == 0)
                {
                    return Int32.MaxValue;
                }

                int root = harr[0];

                if(heap_size > 1)
                {
                    harr[0] = harr[heap_size - 1];
                    minHeapify(0);
                }

                heap_size--;
                return root;
            }

            public void minHeapify(int i)
            {
                int l = left(i);
                int r = right(i);

                int smallest = i;

                if(l < heap_size && harr[l] < harr[i])
                {
                    smallest = l;
                } 
                if(r < heap_size && harr[r] < harr[smallest])
                {
                    smallest = r;
                }
                if(smallest != i)
                {
                    int t = harr[i];
                    harr[i] = harr[smallest];
                    harr[smallest] = t;
                    minHeapify(smallest);
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 12, 3, 5, 7, 19 };
            int n = arr.Length;
            int k = 4;
            Program p = new Program();
            Console.WriteLine("K'th smaller element is " + p.kthSmallest(arr, n, k));

            Console.ReadLine();
        }

        int kthSmallest(int[] arr, int n, int k)
        {
            MinHeap mh = new MinHeap(arr, n);

            for (int i = 0; i < k - 1; i++)
            {
                mh.extractMin();
            }
            return mh.getMin();
        }
    }
}
