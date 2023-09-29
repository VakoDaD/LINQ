using System.Collections;

namespace LINQ
{
    public static class Test2
    {
        public static void Test()
        {
            var arr = new int[] { 1, 2, 3, 4 };

            foreach (var number in new WhereGreaterThanEnumerable(arr, 2))
                Console.WriteLine(number);
        }
    }

    public class WhereGreaterThanEnumerable : IEnumerable<int>
    {
        private readonly IEnumerable<int> _enumerable;
        private readonly int _number;

        public WhereGreaterThanEnumerable(IEnumerable<int> enumerable, int number)
        {
            _enumerable = enumerable;
            _number = number;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new WhereGreaterThanEnumerator(_enumerable, _number);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class WhereGreaterThanEnumerator : IEnumerator<int>
    {
        private readonly int _number;
        private readonly IEnumerator<int> _enumerator;

        public WhereGreaterThanEnumerator(IEnumerable<int> enumerable, int number)
        {
            _number = number;
            _enumerator = enumerable.GetEnumerator();
        }

        public int Current => _enumerator.Current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if (_enumerator.Current > _number)
                {
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            _enumerator.Reset();
        }

        public void Dispose()
        {

        }
    }
}
