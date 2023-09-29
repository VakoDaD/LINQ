namespace LINQ
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public static class Test6
    {
        public static void Test()
        {
            var arr = new VarlamEnumerable<Person>(new Person[]
            {
                new Person()
                {
                    Age = 1,
                    Name = "Test"
                }
            });

            var a = arr.VarlamSelect(x => x.Name);

            var b = 2;
        }
    }

    public static class VarlamExtentions
    {
        public static IEnumerable<TResult> VarlamSelect<T, TResult>(this VarlamEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }

        public static IEnumerable<T> VarlamWhere<T>(this VarlamEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}