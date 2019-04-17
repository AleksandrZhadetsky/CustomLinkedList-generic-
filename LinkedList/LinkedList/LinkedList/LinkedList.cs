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

        public bool IsReadOnly => throw new System.NotImplementedException();

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

        public void CopyTo(T[] array, int startIndex)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void Insert(int index, T value)
        {
            throw new System.NotImplementedException();
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
    }
}
