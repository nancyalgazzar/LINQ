using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static linq.ListGenerators;

namespace linq
{
    class sensitiveComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x == null || y == null) return -1;
            return string.Compare(x.ToLower(), y.ToLower());
        }
    }
    class stringComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
           if(x == null || y == null)
                return false;
            var s = new string(x.ToLower().Trim().Order().ToArray());
            var z = new string(y.ToLower().Trim().Order().ToArray());
           return s==z ;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.Trim().Length.GetHashCode();
        }
    }

    internal class Program
    {
        static void printProducts(List<Product> l)
        {
            foreach (Product p in l)
                Console.WriteLine(p);
        }
        static void Main(string[] args)
        {
            string[] numsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] fruitArr = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"];

            int[] numsiArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //1
            #region  LINQ - Restriction Operators
            //var res = ProductList.Where(p => p.UnitsInStock == 0).ToList();
            //printProducts(res);
            //Console.WriteLine("###############################################################");
            ////2
            //res = ProductList.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3.00M).ToList();
            //printProducts(res);
            //Console.WriteLine("###############################################################");
            ////3
            //var nums = numsArr.Where((a, i) => a.Length < i).ToArray();
            //foreach (var i in nums) Console.Write($"{i} ");
            //Console.WriteLine();
            #endregion
            //Console.WriteLine("\n###############################################################\n");
            #region Element Operators
            //4
            //var sssss = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);// better imp
            //var firstP = ProductList.Where(p => p.UnitsInStock == 0).FirstOrDefault();
            //Console.WriteLine(firstP);
            //Console.WriteLine("###############################################################");

            ////5
            //var firstP1000 = ProductList.Where(p => p.UnitPrice > 1000).FirstOrDefault();
            //Console.WriteLine(firstP1000?.ToString() ?? "NA");
            //Console.WriteLine("###############################################################");

            ////6
            //var g5 = numsiArr.Where(i => i > 5).OrderByDescending(i => i).ElementAtOrDefault(1);
            //Console.WriteLine(g5);
            #endregion
            //Console.WriteLine("\n###############################################################\n");
            #region Ordering Operators

            //var result = ProductList.OrderBy(p => p.ProductName).ToList();// better not to use to list alot for memory
            ////use toList to store for multiple use, function return, loops that affect the list
            //printProducts(result);
            //Console.WriteLine("\n###############################################################\n");

            ////2
            ////var ord = Arr.OrderBy(i => i, StringComparer.OrdinalIgnoreCase);
            ////foreach (var i in ord)
            ////    Console.Write($"{i}   ");
            ////Console.WriteLine();
            //var ord = fruitArr.OrderBy(i => i, new sensitiveComparer());
            //foreach (var i in ord)
            //    Console.Write($"{i}   ");
            //Console.WriteLine("\n###############################################################\n");


            ////3

            //result = ProductList.OrderByDescending(p => p.UnitsInStock).ToList();

            //printProducts(result);
            ////4
            //Console.WriteLine("\n###############################################################\n");

            //ord = numsArr.OrderBy(a => a.Length).ThenBy(a => a);
            //foreach (var i in ord)
            //    Console.Write($"{i}   ");

            ////5
            //Console.WriteLine("\n###############################################################\n");

            //ord = fruitArr.OrderBy(a => a.Length).ThenBy(i => i, StringComparer.OrdinalIgnoreCase);
            //foreach (var i in ord)
            //    Console.Write($"{i}   ");
            ////6
            //Console.WriteLine("\n###############################################################\n");

            //var ss = ProductList.OrderByDescending(p => p.Category).ThenByDescending(p => p.UnitPrice).ToList();
            //printProducts(ss);
            ////7
            //Console.WriteLine("\n###############################################################\n");

            //var sarr = fruitArr.OrderBy(a => a.Length).ThenByDescending(i => i, StringComparer.OrdinalIgnoreCase).ToArray();
            //foreach (var i in sarr) Console.WriteLine(i);
            ////8
            //Console.WriteLine("\n###############################################################\n");

            //var rev = numsArr.Where(i => i?.Length > 2 && i?[1] == 'i').Reverse().ToList();
            //foreach (var i in rev) Console.WriteLine(i);
            #endregion
            //Console.WriteLine("\n###############################################################\n");
            #region  Projection Operators

            //var names = ProductList.Select(p => p.ProductName).ToList();
            //foreach (var name in names) Console.WriteLine(name);
            ////2
            //Console.WriteLine("\n###############################################################\n");

            //var upp = fruitArr.Select(a => new { data = a, upper = a.ToUpper(), lower = a.ToLower(), });
            //foreach (var i in upp)
            //    Console.WriteLine($"{i.data} {i.upper} {i.lower}");
            ////3
            //Console.WriteLine("\n###############################################################\n");

            //var some = ProductList.Select(p => new { price = p.UnitPrice, name = p.ProductName }).ToList();
            //foreach (var i in some) Console.WriteLine($"{i.name} {i.price}");
            ////4
            //Console.WriteLine("\n###############################################################\n");

            //int[] nArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var match = nArr.Select((n, i) => new { num = n, ch = n.Equals(i) }).ToArray();
            //foreach (var i in match) Console.WriteLine($"{i.num}: {i.ch}");
            //Console.WriteLine("\n###############################################################\n");

            ////5
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var temp = numbersA.SelectMany(n => { List<string> l = new(); foreach (var s in numbersB) if (s > n) l.Add($"{n} less than {s}"); return l; });
            //foreach (var i in temp) Console.WriteLine(i);
            //Console.WriteLine("\n###############################################################\n");

            ////6
            //var sss = from c in CustomerList
            //          from o in c.Orders
            //          where o.Total < 500
            //          select o;

            //var orders = CustomerList.SelectMany(c => c.Orders.Where(o => o.Total < 500));
            //foreach (var o in orders) Console.WriteLine(o);
            //Console.WriteLine("\n###############################################################\n");
            //Console.WriteLine(orders.Count());
            //Console.WriteLine(sss.Count());
            //Console.WriteLine("\n###############################################################\n");

            ////7
            //orders = CustomerList.SelectMany(c => c.Orders.Where(o => o.OrderDate.Year >= 1998));
            //foreach (var o in orders) Console.WriteLine(o);
            #endregion
            Console.WriteLine("\n##########################Set operations#####################################\n");
            //#region Set operations
            ////1

            //var uniqueNames = ProductList.Select(p => p.Category).Distinct();
            //foreach (var o in uniqueNames) Console.WriteLine(o);
            ////2
            //Console.WriteLine("\n###############################################################\n");

            //var uniqFirstName = ProductList.Select(p => { var temp = p.ProductName.Split(' '); return temp?[0] ?? string.Empty; }).
            //    Union(CustomerList.Select(p => { var temp = p.CompanyName.Split(' '); return temp?[0] ?? string.Empty; }));
            //var sssss = (from p in ProductList
            //             let p1 = p.ProductName.Split(" ")?[0] ?? string.Empty
            //             select p1).Union(from c in CustomerList
            //                              let c1 = c.CompanyName.Split(" ")?[0] ?? string.Empty
            //                              select c1);
            //Console.WriteLine(sssss.Count());
            //Console.WriteLine(uniqFirstName.Count());
            //Console.WriteLine("\n###############################################################\n");

            ////3

            //var commonLetter = ProductList.Select(p => p.ProductName[0]).Intersect(CustomerList.Select(c => c.CompanyName[0]));
            //Console.WriteLine(commonLetter.Count());
            //foreach (var c in commonLetter) Console.Write(c.ToString());
            //Console.WriteLine("\n###############################################################\n");

            ////4
            //var notcommonLetter = ProductList.Select(p => p.ProductName[0]).Except(CustomerList.Select(c => c.CompanyName[0]));
            //Console.WriteLine(notcommonLetter.Count());
            //foreach (var c in notcommonLetter) Console.Write(c.ToString());
            //Console.WriteLine("\n###############################################################\n");

            ////5
            //var last3 = ProductList.Select(p => p.ProductName[^3..]).Union(CustomerList.Select(c => c.CompanyName[^3..]));
            //foreach (var item in last3) Console.WriteLine(item);


            //#endregion
            //Console.WriteLine("\n#########################Aggregate Operators######################################\n");
            //#region Aggregate Operators
            //// need revice
            ////1
            //var odds = numsiArr.Count(n => n % 2 == 1);
            //Console.WriteLine(odds);
            //Console.WriteLine("\n###############################################################\n");

            ////2
            ////var cusAndOrd = CustomerList.GroupBy(c=>c.CustomerID,c=>c.Orders.Length);
            ////foreach (var co in cusAndOrd) Console.WriteLine($"{co.Key}  {co.First()}");
            //var cusAndOrd = CustomerList.Select(c => new { id = c.CustomerID, orders = c.Orders.Length });
            //foreach (var co in cusAndOrd) Console.WriteLine(co);
            //Console.WriteLine("\n###############################################################\n");

            ////3
            //var categoryies = ProductList.CountBy(p => p.Category);
            //foreach (var c in categoryies) Console.WriteLine(c);

            //Console.WriteLine("\n###############################################################\n");
            ////4

            //Console.WriteLine(numsiArr.Sum());
            //Console.WriteLine("\n###############################################################\n");

            ////5
            StreamReader sr = new StreamReader("dictionary_english.txt");
            string[] dict = sr.ReadToEnd().Split('\n');
            sr.Close();
            //var allchar = dict.Sum(x => x.Length);
            //Console.WriteLine(allchar);
            //Console.WriteLine("\n###############################################################\n");
            ////6
            //var totalunits = ProductList.AggregateBy(p => p.Category, 0, (sum, p) => sum + p.UnitsInStock);
            //foreach (var item in totalunits)
            //    Console.WriteLine($"{item.Key}  {item.Value}");
            //Console.WriteLine("\n###############################################################\n");
            ////7
            //var shortest = dict.MinBy(d => d.Length);
            //Console.WriteLine(shortest?.Length);
            //Console.WriteLine("\n###############################################################\n");
            ////8
            //var minpriceIncat = ProductList.AggregateBy(p => p.Category, decimal.MaxValue, (min, p) => Math.Min(min, p.UnitPrice));
            //foreach (var item in minpriceIncat) Console.WriteLine(item);
            //Console.WriteLine("\n###############################################################\n");
            ////9
            //var minpriceIncat2 = from p in ProductList
            //                     group p by p.Category into g
            //                     let min = g.Min(p => p.UnitPrice)
            //                     from l in g
            //                     where l.UnitPrice == min
            //                     select l;

            //foreach (var item in minpriceIncat2) Console.WriteLine(item);
            ////10
            //Console.WriteLine("\n###############################################################\n");
            //var longest = dict.MaxBy(d => d.Length);
            //Console.WriteLine(longest?.Length);
            //Console.WriteLine("\n###############################################################\n");
            ////11
            //var maxpricepercat = ProductList.AggregateBy(p => p.Category, decimal.MinValue, (min, p) => Math.Max(min, p.UnitPrice));
            //foreach (var item in maxpricepercat) Console.WriteLine(item);
            //Console.WriteLine("\n###############################################################\n");
            ////12
            //var maxProductPerCat = from p in ProductList
            //                       group p by p.Category into g
            //                       let max = g.Max(p => p.UnitPrice)
            //                       from l in g
            //                       where l.UnitPrice == max
            //                       select l;
            //foreach (var m in maxProductPerCat) Console.WriteLine(m);
            //Console.WriteLine("\n###############################################################\n");
            ////13
            //double avgLength = dict.Average(d => d.Length);
            //Console.WriteLine(avgLength);
            //Console.WriteLine("\n###############################################################\n");
            ////14
            //var avgpricepercat = ProductList.GroupBy(p => p.Category).Select(p => new { c = p.Key, avg = p.Average(v => v.UnitPrice) });
            //foreach (var item in avgpricepercat) Console.WriteLine(item);
            //Console.WriteLine("\n###############################################################\n");

            //#endregion
            //Console.WriteLine("\n################Partitioning Operators###############################################\n");
            //#region Partitioning Operators
            ////1
            //var first3orders = CustomerList.Where(c => c.City == "London").SelectMany(c => c.Orders.Take(3));
            //foreach (var order in first3orders) Console.WriteLine(order);
            //Console.WriteLine("\n###############################################################\n");
            ////2
            //var skip2orders = CustomerList.Where(c => c.City == "London").SelectMany(c => c.Orders.Skip(2));
            //foreach (var order in skip2orders) Console.WriteLine(order);
            //Console.WriteLine("\n###############################################################\n");
            ////3
            //var taketill = numsiArr.TakeWhile((n, i) => n > i);
            //foreach (var n in taketill) Console.WriteLine(n);
            //Console.WriteLine("\n###############################################################\n");
            ////4
            //var divisibleBy3 = numsiArr.Where(n => n % 3 == 0);
            //foreach (var n in divisibleBy3) Console.WriteLine(n);
            //Console.WriteLine("\n###############################################################\n");
            ////5
            //var lessthanIndex = numsiArr.Where((n, i) => n < i);
            //foreach (var n in lessthanIndex) Console.WriteLine(n);
            //#endregion
            //Console.WriteLine("\n###########################Quantifiers####################################\n");
            //#region Quantifiers
            //1
            var containsEI = dict.Where((p)=>(Regex.IsMatch(p, ".*ei.*") == true));
                Console.WriteLine(containsEI.Count());
                Console.WriteLine(dict.Count());
            Console.WriteLine("\n###############################################################\n");
            //2
            //var products = ProductList.GroupBy(p => p.Category).Where(g => g.Any(p => p.UnitsInStock == 0));
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Key);
            //    foreach (var item in product)
            //    {
            //        Console.WriteLine($"::::{item}");
            //    }
            //}
            //Console.WriteLine("\n###############################################################\n");
            ////3
            //products = ProductList.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock == 0));
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Key);
            //    foreach (var item in product)
            //    {
            //        Console.WriteLine($"::::{item}");
            //    }
            //}
            ////#endregion
            ////Console.WriteLine("\n########################Grouping Operators#######################################\n");
            ////#region Grouping Operators
            ////1
            //var partitionBy5 = from n in numsiArr
            //                   group n by n % 5 into g
            //                   orderby g.Key
            //                   select g;
            //foreach (var n in partitionBy5)
            //{
            //    Console.WriteLine($"Numbers with a remainder of {n.Key} when divided by 5:");
            //    foreach (var item in n)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //Console.WriteLine("\n###############################################################\n");
            ////2
            //var firstchar = dict.GroupBy(g => g?[0]);
            //foreach (var n in firstchar)
            //{
            //    Console.WriteLine($" {n.Key}  {n.Count()}");

            //}
            //Console.WriteLine("\n###############################################################\n");
            ////3
            //string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            //var sameLength = Arr.GroupBy(a => a, new stringComparer());
            //foreach (var n in sameLength)
            //{
            //    Console.WriteLine($"{n.Key.Trim().Length}");
            //    foreach (var item in n)
            //    {
            //        Console.WriteLine($":::{item}");
            //    }
            //}
            //#endregion
        }
    }
}
