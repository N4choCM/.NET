using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1. SELECT * FROM cars
            var carList = from car in cars select car;

            foreach(var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. 2. SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach(var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        //Number examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Each number multiplied by 3

            //take all numbers, but 9

            //Order numbers by ascending value

            var processedNumberList =
                numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //First of all elements
            var first = textList.First();

            //First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //First element containing a "j"
            var jText = textList.First(text => text.Contains("j"));

            //First element containing "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            //Last element containing "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            //Single Values
            var uniqueTexts = textList.Single();

            //Single Values or Default
            var uniqueTextsOrDefault = textList.SingleOrDefault();


            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain {4, 8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionsSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Nacho",
                            Email = "nachocamposmarti@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Laura",
                            Email = "laura@gmail.com",
                            Salary = 4500
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Pepe",
                            Email = "pepe@gmail.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 4,
                            Name = "Juan",
                            Email = "juan@gmail.com",
                            Salary = 2999
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 5,
                            Name = "Ana",
                            Email = "ana@gmail.com",
                            Salary = 5500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Julia",
                            Email = "julia@gmail.com",
                            Salary = 1873
                        },
                        new Employee
                        {
                            Id = 7,
                            Name = "Josefa",
                            Email = "josefa@gmail.com",
                            Salary = 4300
                        },
                        new Employee
                        {
                            Id = 8,
                            Name = "Adrián",
                            Email = "adri@gmail.com",
                            Salary = 3999
                        }
                    }
                }
            };

            //Obtain all employees of all enterprises
            var employeesList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Know if any list is empty
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            //Enterprises having at leat an employee earning more than or equal to 3000 €
            bool hasEmployeeWithSalaryMoreThan3000 =
                enterprises.Any(enterprise =>
                enterprise.Employees.Any(employee => employee.Salary >= 3000));
        }

        static public void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            //Otra forma más liosa de hacer INNER JOINS
            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new {element, secondElement });

            //OUTER JOIN - LEFT - TWO WAYS
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new {Element = element, SecondElement = secondElement };

            //OUTER JOIN - RIGHT - TWO WAYS
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            //SKIP
            var skipFirstTwoValues = myList.Skip(2);
            var skipLastTwoValues = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(num => num < 4);

            //TAKE
            var takeFirstTwoValues = myList.Take(2);
            var takeLastTwoValues = myList.TakeLast(2);
            var takeWhile = myList.TakeWhile(num => num < 4);


        }
    }
}