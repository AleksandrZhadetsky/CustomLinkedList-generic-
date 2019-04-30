using System;
using System.Collections;

namespace LinkedList.LinkedList
{
    public class CustomLinkedList<T> : IList.IList<T>
    {
        public CustomLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public CustomLinkedList(T data)
        {
            Initialize(data);
        }

        public CustomLinkedList(System.Collections.Generic.IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public CustomLinkedListNode<T> First => Head;
        public CustomLinkedListNode<T> Last => Tail;
        public CustomLinkedListNode<T> Head { get; private set; }
        public CustomLinkedListNode<T> Tail { get; private set; }
        public T this[int index]
        {
            get
            {
                var counter = 0;
                var current = Head;
                while (counter < index)
                {
                    current = current.Next;
                    counter++;
                }

                return current.Data;
            }
            set
            {
                var counter = 0;
                var current = Head;
                while (counter < index)
                {
                    current = current.Next;
                    counter++;
                }

                current.Data = value;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T data)
        {
            if (Tail != null)
            {
                var item = new CustomLinkedListNode<T>(data);
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
                Count++;
            }
            else
            {
                Initialize(data);
            }
        }

        private void Initialize(T value)
        {
            var item = new CustomLinkedListNode<T>(value);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public void CopyTo(T[] array, int startIndex = 0)
        {
            if (array.Length - startIndex >= Count)
            {
                int j = 0;
                for (int i = startIndex; i < Count; i++)
                {
                    array[i] = this[j++];
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T value)
        {
            var newNode = new CustomLinkedListNode<T>(value);
            var current = Head;
            int counter = 0;

            if (!ReferenceEquals(Head, current))
            {
                while (counter < index)
                {
                    current = current.Next;
                    counter++;
                }

                current.Previous.Next = newNode;
                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous = newNode;
                Count++;
            }
            else
            {
                current.Previous = newNode;
                newNode.Next = current;
                Head = newNode;
                Count++;
            }
        }

        public bool Remove(T value)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(value))
                {
                    Head.Next.Previous = null;
                    Head = Head.Next;
                    Count--;
                    return true;
                }

                var current = Head.Next;
                var previous = Head;

                while (!current.Data.Equals(value))
                {
                    previous = current;
                    current = current.Next;
                }

                if (current.Next == null)
                {
                    previous.Next = null;
                    current.Previous = null;
                    Count--;
                    return true;
                }

                previous.Next = current.Next;
                current.Next.Previous = previous;
                Count--;
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        public CustomLinkedListNode<T> Find(T value)
        {
            if (Head != null)
            {
                var current = Head;
                while (current.Next != null)
                {
                    if (current.Data.Equals(value))
                    {
                        return current;
                    }

                    current = current.Next;
                }
            }
            return null;
        }

        public void AddAfter(CustomLinkedListNode<T> node, CustomLinkedListNode<T> newNode)
        {
            node.Next.Previous = newNode;
            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next = newNode;
            Count++;
        }

        public CustomLinkedListNode<T> AddAfter(CustomLinkedListNode<T> node, T value)
        {
            var newNode = new CustomLinkedListNode<T>(value);
            node.Next.Previous = newNode;
            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next = newNode;
            Count++;
            return newNode;
        }

        public void AddBefore(CustomLinkedListNode<T> node, CustomLinkedListNode<T> newNode)
        {
            node.Previous.Next = newNode;
            newNode.Previous = node.Previous;
            newNode.Next = node;
            node.Previous = newNode;
            Count++;
        }

        public CustomLinkedListNode<T> AddBefore(CustomLinkedListNode<T> node, T value)
        {
            var newNode = new CustomLinkedListNode<T>(value) { Previous = node.Previous };
            node.Previous.Next = newNode;
            newNode.Next = node;
            node.Previous = newNode;
            Count++;

            return newNode;
        }

        public void AddFirst(CustomLinkedListNode<T> node)
        {
            Head.Previous = node;
            node.Next = Head;
            Head = node;
            Count++;
        }

        public CustomLinkedListNode<T> AddFirst(T value)
        {
            Head.Previous = new CustomLinkedListNode<T>(value) { Next = Head };
            Head = Head.Previous;
            Count++;
            return Head;
        }

        public void AddLast(CustomLinkedListNode<T> node)
        {
            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
            Count++;
        }

        public CustomLinkedListNode<T> AddLast(T value)
        {
            Add(value);
            return Tail;
        }

        public CustomLinkedListNode<T> FindLast(T value)
        {
            var current = Tail;
            while (current.Previous != null)
            {
                if (current.Data.Equals(value)) return current;
                current = current.Previous;
            }

            return null;
        }

        public void Remove(CustomLinkedListNode<T> node)
        {
            if (ReferenceEquals(node, Head))
            {
                RemoveFirst();
                return;
            }

            if (ReferenceEquals(node, Tail))
            {
                RemoveLast();
                return;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Next = null;
            node.Previous = null;
            Count--;
        }

        public void RemoveFirst()
        {
            Head = Head.Next;
            Head.Previous.Next = null;
            Head.Previous = null;
            Count--;
        }

        public void RemoveLast()
        {
            Tail = Tail.Previous;
            Tail.Next.Previous = null;
            Tail.Next = null;
            Count--;
        }
    }
}
