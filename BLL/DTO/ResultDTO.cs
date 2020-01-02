using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class ResultDTO
    {
        public int Id { get; set; }
        public double Mark { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public int[] AnswerIds { get; set; }
    }
}
