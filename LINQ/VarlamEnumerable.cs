using System.Collections;

namespace LINQ
{
    public static class Test1
    {
        public static void Test()
        {
            var arr = new int[] { 1, 2, 3, 4 };

            foreach (var number in new VarlamEnumerable<int>(arr))
                Console.WriteLine(number);
        }
    }

    public class VarlamEnumerable<T> : IEnumerable<T>
    {
        private readonly T[] _items;

        public VarlamEnumerable(params T[] items)
        {
            _items = items;
        }

        public IEnumerator<T> GetEnumerator() => new VarlamEnumerator<T>(_items);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class VarlamEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _array;
        private int _position = -1;

        public VarlamEnumerator(params T[] array)
        {
            _array = array;
        }

        public T Current => _array[_position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return ++_position < _array.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}