using System;

namespace LinkedList.LinkedList
{
    public class CustomLinkedListNode<T>
    {
        private T _data;
        public CustomLinkedListNode(T data)
        {
            Data = data;
        }

        public CustomLinkedListNode()
        {
            Data = default(T);
        }

        //public CustomLinkedList<T> List { get; }

        public CustomLinkedListNode<T> Next { get; set; } = null;

        public CustomLinkedListNode<T> Previous { get; set; } = null;

        public T Data
        {
            get => _data;
            set
            {
                if (value != null)
                {
                    _data = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj is CustomLinkedListNode<T> target && Data.Equals(target.Data);
        }

        public bool Equals(CustomLinkedListNode<T> obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Data.Equals(obj.Data);
        }

        //TODO: implement custom hash-function
        public override int GetHashCode() 
        {
            return 0;
        }

        public new CustomLinkedListNode<T> MemberwiseClone() => new CustomLinkedListNode<T>(Data);

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
