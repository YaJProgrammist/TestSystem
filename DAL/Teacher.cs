using System.Collections.Generic;

namespace DAL
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}
