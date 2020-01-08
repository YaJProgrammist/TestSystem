using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        TestDTO GetTest(int? id);
        IEnumerable<TestDTO> GetTests(Predicate<TestDTO> predic);
        void AddTest(TestDTO testDTO);
        void UpdateTest(TestDTO testDTO);
        void DeleteTest(int? id);
        void Dispose();
    }
}
