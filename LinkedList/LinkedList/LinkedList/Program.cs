using System;
using LinkedList.LinkedList;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            //var array = new int[6];
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
            //Console.WriteLine("indexator testing [4] " + list[4]);
            //Console.WriteLine("Count property (should have value=5) " + list.Count);

            //Console.WriteLine("Remove test");
            //list.Remove(2);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("Count property (should have value=4) " + list.Count);

            //Console.WriteLine("CopyTo test");
            //list.CopyTo(array, 0);
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("IndexOf(10) test");
            // Console.WriteLine(list.IndexOf(10));

            //Console.WriteLine("CopyTo test");
            //list.CopyTo(array, 0);
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("Insert(0, 10) test");
            list.Insert(0, 10);
            ////Console.WriteLine(list.Count);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Remove(list[]) test");
            //list.Remove(list[0]);
            //list.RemoveFirst();
            //list.RemoveLast();
            Console.WriteLine();
            //list.Remove(list[3]);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("count is: " + list.Count);

        }
    }
}
