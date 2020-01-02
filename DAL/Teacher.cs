using System.Collections.Generic;

namespace DAL
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Test> Tests { get; set; }
    }
}
