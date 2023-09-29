using System.Collections;

namespace LINQ
{
    public static class Test3
    {
        public static void Test()
        {
            var arr = new int[] { 1, 20, 3, 80 };

            foreach (var item in new SelectEnumerable<int, string>(arr, x => "Hello" + x.ToString()))
            {
                Console.WriteLine(item);
            }
        }
    }

    public class SelectEnumerator<TIn, TOut> : IEnumerator<TOut>
    {
        private readonly Func<TIn, TOut> _converter;
        private readonly IEnumerator<TIn> _enumerator;

        public SelectEnumerator(IEnumerable<TIn> enumerable, Func<TIn, TOut> converter)
        {
            _converter = converter;
            _enumerator = enumerable.GetEnumerator();
        }

        public TOut Current => _converter(_enumerator.Current);

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }

    public class SelectEnumerable<TIn, TOut> : IEnumerable<TOut>
    {
        private readonly Func<TIn, TOut> _converter;
        private readonly IEnumerable<TIn> _enumerable;

        public SelectEnumerable(IEnumerable<TIn> enumerable, Func<TIn, TOut> converter)
        {
            _enumerable = enumerable;
            _converter = converter;
        }

        public IEnumerator<TOut> GetEnumerator()
        {
            return new SelectEnumerator<TIn, TOut>(_enumerable, _converter);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}