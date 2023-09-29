namespace LINQ
{
    public static class Test7
    {
        public static void Test()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Name = "Tomara",
                    Weight = 109,
                    Tasks = new List<string>
                    {
                        "Excel შეტვირთვა",
                        "Excel განტვირთვა"
                    }
                },
                new Employee
                {
                    Name = "Varlama",
                    Weight = 91,
                    Tasks = new List<string>
                    {
                        "დაპაკეტება"
                    }
                },
                new Employee
                {
                    Name = "Nino",
                    Weight = 48,
                    Tasks = new List<string>
                    {
                        "2 დონიანი ავტორიზაცია",
                        "family members"
                    }
                },
                new Employee
                {
                    Name = "Nino",
                    Weight = 51,
                    Tasks = new List<string>
                    {
                        "Product pricing",
                        "ანკეტა"
                    }
                },
                new Employee
                {
                    Name = "Mari",
                    Weight = 51,
                    Tasks = new List<string>
                    {
                        "გამოწერა",
                        "search"
                    }
                }
            };

            #region Query vs Lambda

            //var querySyntax = from employee in employees
            //                  where employee.Weight > 60
            //                  select employee;

            //var methodSyntax = employees.Where(e => e.Weight == 10);

            //Console.WriteLine("Query Syntax Results:");
            //foreach (var employee in querySyntax)
            //{
            //    Console.WriteLine(employee.Name);
            //}

            #endregion

            #region Select

            //var taskLists = employees.Select(e => e.Tasks);

            //foreach (var tasks in taskLists)
            //{
            //    foreach (var task in tasks)
            //    {
            //        Console.WriteLine(task);
            //    }
            //}

            //var allTasks = employees.SelectMany(e => e.Tasks);

            //foreach (var task in allTasks)
            //{
            //    Console.WriteLine(task);
            //}

            //var employeeNamesWithIndex = employees.Select((e, index) => $"{index + 1}. {e.Name}");

            //foreach (var item in employeeNamesWithIndex)
            //{
            //    Console.WriteLine(item);
            //}

            //var allTasksWithIndex = employees.SelectMany((e, index) => e.Tasks.Select(task => $"{index + 1}. {task}"));

            //foreach (var item in allTasksWithIndex)
            //{
            //    Console.WriteLine(item);
            //}

            ////result selector
            //var taskWithEmployeeName = employees.SelectMany(e => e.Tasks, (e, task) => $"{e.Name}: {task}");

            //foreach (var item in taskWithEmployeeName)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Where

            //var heavyEmployees = employees.Where(e => e.Weight > 91);

            //Console.WriteLine("Heavy Employees: " + string.Join(", ", heavyEmployees.Select(e => e.Name)));

            //var indexedHeavyEmployees = employees.Where((e, index) => e.Weight > 100 && index < 10);

            #endregion

            #region First/FirstOrDefault

            try
            {
                //var firstNino = employees.First();
                var firstNino = employees.First(e => e.Name == "Nino");
                
                Console.WriteLine("First employee named Nino: " + firstNino.Name);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);  
            }

            //var firstOrDefault = employees.FirstOrDefault();
            var firstOrDefault = employees.FirstOrDefault(e => e.Name == "Melchizedek");
            
            if (firstOrDefault == null)
            {
                Console.WriteLine("No employee named Melchizedek found."); 
            }

            #endregion

            #region Single/SingleOrDefault

            try
            {
                var singleVarlama = employees.Single(e => e.Name == "Varlama");
                Console.WriteLine("Single employee named Varlama: " + singleVarlama.Name);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            var singleOrDefaultJohn = employees.SingleOrDefault(e => e.Name == "Melchizedek");
            if (singleOrDefaultJohn == null)
            {
                Console.WriteLine("No employee named Melchizedek found.");  
            }

            #endregion

            #region Any

            //var anyBusyEmployee = employees.Any(e => e.Tasks.Count() > 2);

            //Console.WriteLine("Any busy employee: " + anyBusyEmployee);

            //#endregion

            //#region All

            //var allEmployeesHaveTasks = employees.All(e => e.Tasks.Any());

            //Console.WriteLine("All employees have tasks: " + allEmployeesHaveTasks);

            #endregion

            #region Sum

            //var totalWeight = employees.Sum(e => e.Weight);

            //Console.WriteLine("Total weight: " + totalWeight);

            #endregion

            #region Average

            var averageWeight = employees.Average(e => e.Weight);

            Console.WriteLine("Average weight: " + averageWeight);

            #endregion

            #region Max/Min

            //var maxWeight = employees.Max(e => e.Weight);
            //Console.WriteLine("Max weight: " + maxWeight);

            //var minWeight = employees.Min(e => e.Weight);
            //Console.WriteLine("Min weight: " + minWeight);

            #endregion

            #region Distinct

            //var distinctNames = employees.Select(e => e.Name).Distinct();
            //Console.WriteLine("Distinct names: " + string.Join(", ", distinctNames));

            //var distinctEmployees = employees.Distinct(new EmployeeComparer());
            //Console.WriteLine("Distinct employees: " + string.Join(", ", distinctEmployees.Select(e => e.Name)));

            #endregion

            #region Skip/Take

            //var firstThreeEmployees = employees.Take(3);
            //Console.WriteLine("First three employees: " + string.Join(", ", firstThreeEmployees.Select(e => e.Name))); 

            //var skipThreeEmployees = employees.Skip(3);
            //Console.WriteLine("After skipping three employees: " + string.Join(", ", skipThreeEmployees.Select(e => e.Name)));

            #endregion

            #region Reverse

            //employees.Reverse();
            //Console.WriteLine("Reversed list: " + string.Join(", ", employees.Select(e => e.Name))); 

            #endregion

            #region Order By

            //var orderedByWeight = employees.OrderBy(student => student.Weight);

            //foreach (var employee in orderedByWeight)
            //{
            //    Console.WriteLine($"Name: {employee.Name}, Weight: {employee.Weight}");
            //} 

            #endregion

            #region Except

            var heavierEmployees = employees.Except(employees.Where(e => e.Weight < 60));
            
            Console.WriteLine("Employees with weight 50 or more: " + string.Join(", ", heavierEmployees.Select(e => e.Name)));

            #endregion

            #region Group

            //var groupedByWeight = employees.GroupBy(s => s.Weight).ToList();

            //var key = groupedByWeight.First().Key;

            //foreach (var group in groupedByWeight)
            //{
            //    Console.WriteLine($"Grade: {group.Key}");
            //    foreach (var student in group)
            //    {
            //        Console.WriteLine($"\tStudent: {student.Name}");
            //    }
            //}

            //Console.WriteLine();

            //var groupedByWeightAndFirstLetter = employees
            //    .GroupBy(s => new { s.Weight, FirstLetter = s.Name[0] });

            //foreach (var group in groupedByWeightAndFirstLetter)
            //{
            //    Console.WriteLine($"Grade: {group.Key.Weight}, First Letter: {group.Key.FirstLetter}");
            //    foreach (var student in group)
            //    {
            //        Console.WriteLine($"\tStudent: {student.Name}");
            //    }
            //}

            //Console.WriteLine();

            //var averageWeightByFirstLetter = employees
            //    .GroupBy(s => s.Name[0])
            //    .Select(g => new
            //    {
            //        FirstLetter = g.Key,
            //        AverageWeight = g.Average(s => s.Weight)
            //    });

            //foreach (var group in averageWeightByFirstLetter)
            //{
            //    Console.WriteLine($"First Letter: {group.FirstLetter}, Average Weight: {group.AverageWeight}");
            //}

            ////overload with 2 arguments
            //var groupedByWeight2 = employees
            //.GroupBy(
            //    student => student.Weight, // key selector
            //    (weight, employeeInWeight) => new // result selector
            //    {
            //        Weight = weight,
            //        EmployeeCount = employeeInWeight.Count()
            //    }
            //);

            //foreach (var weightGroup in groupedByWeight2)
            //{
            //    Console.WriteLine($"Weight: {weightGroup.Weight}, Employee Count: {weightGroup.EmployeeCount}");
            //}


            #endregion

            Console.ReadKey();
        }
    }

    public class Employee
    {
        public string Name { get; set; }

        public decimal Weight { get; set; }

        public IEnumerable<string> Tasks { get; set; }
    }

    class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.Name == y.Name && x.Weight == y.Weight;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode() ^ obj.Weight.GetHashCode();
        }
    }
}