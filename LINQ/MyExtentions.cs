namespace LINQ
{
    public static class Test4
    {
        public static void Test()
        {
            var arr = new int[] { 1, 20, 3, 80 };
            var withWhere = new WhereGreaterThanEnumerable(arr, 5);

            var a  = arr.MySelect(x => x).MyWhere(5);
            
            var multiplied = new SelectEnumerable<int, int>(withWhere, x => x * 2);

            foreach (var item in new SelectEnumerable<int, string>(multiplied, x => "Hello" + x.ToString()))
            {
                Console.WriteLine(item);
            }
        }
    }

    static class MyEnumerableExtentions
    {
        public static IEnumerable<TOut> MySelect<TIn, TOut>(this IEnumerable<TIn> enumerator, Func<TIn, TOut> converter)
        {
            return new SelectEnumerable<TIn, TOut>(enumerator, converter);
        }

        public static IEnumerable<int> MyWhere(this IEnumerable<int> enumerator, int number)
        {
            return new WhereGreaterThanEnumerable(enumerator, number);
        }
    }
}