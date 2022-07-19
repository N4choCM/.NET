using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    internal class Courses
    {
        public int Id { get; set; }
        public enum Level
        {
            Basic,
            Intermediate,
            Advanced
        }
        public int NumberOfStudents { get; set; }
        public enum Category
        {
            English,
            Programming,
            LifeSkills
        }
    }
}
