using System.Collections.Generic;

namespace BLL.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> TestIds { get; set; }
    }
}
