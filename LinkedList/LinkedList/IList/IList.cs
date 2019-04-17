
namespace LinkedList.IList
{
    interface IList<T>
    {
        int Count { get; }
        bool IsReadOnly { get; }
        T this[int index] { get; set; }

        void Add(T item);
        void Clear();
        bool Contains(T item);
        void CopyTo(T[] array, int startIndex);
        System.Collections.IEnumerator GetEnumerator();
        int IndexOf(T item);
        void Insert(int index, T item);
        bool Remove(T item);
        void RemoveAt(int index);
    }
}
