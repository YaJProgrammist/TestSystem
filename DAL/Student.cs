using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Student
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
