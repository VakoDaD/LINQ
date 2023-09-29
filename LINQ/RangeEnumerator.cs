using System.Collections;

namespace LINQ
{
    public static class Test5
    {
        public static void Test()
        {
            var range = new RangeEnumerable(10, 200_000_000);
            var withWhere = new WhereGreaterThanEnumerable(range, 5);
            var multiplied = new SelectEnumerable<int, int>(withWhere, x => x * 2);
            var x = 0;

            foreach (var item in multiplied)
            {
                x++;
                Console.WriteLine(item);

                if (x > 20)
                    break;
            }
        }
    }

    public class RangeEnumerator : IEnumerator<int>
    {
        private int _current;
        private readonly int _from;
        private readonly int _to;

        public RangeEnumerator(int from, int to)
        {
            _current = from - 1;
            _from = from;
            _to = to;
        }

        public int Current => _current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            return ++_current < _to;
        }

        public void Reset()
        {
            _current = _from;
        }

        public void Dispose()
        {

        }
    }

    public class RangeEnumerable : IEnumerable<int>
    {
        private readonly int _from;
        private readonly int _to;

        public RangeEnumerable(int from, int to)
        {
            _from = from;
            _to = to;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new RangeEnumerator(_from, _to);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}