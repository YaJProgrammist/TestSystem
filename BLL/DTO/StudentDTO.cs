using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<int> ResultIds { get; set; }
    }
}
