using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    internal class Main
    {
        static public void Exercise()
        {
            var users = new[]
            {
                new Users()
                {
                    Id = 1,
                    Name = "Nacho",
                    Email = "nacho@gmail.com"
                },
                new Users()
                {
                    Id = 2,
                    Name = "Laura",
                    Email = "laura@gmail.com"
                },
                new Users()
                {
                    Id = 3,
                    Name = "pepe",
                    Email = "pepe@gmail.com"
                },
                new Users()
                {
                    Id = 4,
                    Name = "lara",
                    Email = "lara@gmail.com"
                }
            };

            var students = new[]
{
                new Students()
                {
                    Id = 1,
                    Name = "Nacho",
                    Email = "nacho@gmail.com",
                    Age = 26,
                    NumberOfCourses = 1
                },
                new Students()
                {
                    Id = 2,
                    Name = "Laura",
                    Email = "laura@gmail.com",
                    Age = 37,
                    NumberOfCourses = 3
                },
                new Students()
                {
                    Id = 3,
                    Name = "Javier",
                    Email = "javivi_sum41@gmail.com",
                    Age = 31,
                    NumberOfCourses = 2
                }
            };

            var courses = new[]
{
                new Courses()
                {
                    Id = 1,
                    NumberOfStudents = 1,
                },
                new Courses()
                {
                    Id = 1,
                    NumberOfStudents = 1
                },
                new Courses()
                {
                    Id = 1,
                    NumberOfStudents = 1
                },
            };

            var usersEmail = from user in users select user.Email;
            var adultStudents = from stu in students
                                where stu.Age > 18
                                select stu;
            var enrolledStudents = from stu in students
                                   where stu.NumberOfCourses >= 1
                                   select stu;
            var coursesHavingAStudent = from course in courses
                                        where course.NumberOfStudents >= 1
                                        select course;
            var coursesWithoutStudents = from course in courses
                                         where course.NumberOfStudents == 0
                                         select course;
        }
    }
}
