using System;
using LinkedList.LinkedList;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            var list = new CustomLinkedList<int>();
            list.Add(1111);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("indexator testing " + list[4]);
            Console.WriteLine("Count property (should have value=5) " + list.Count);

            Console.WriteLine("Remove test");
            list.Remove(2);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Count property (should have value=4) " + list.Count);

        }
    }
}
