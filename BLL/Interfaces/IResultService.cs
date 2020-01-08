using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IResultService
    {
        ResultDTO GetResult(int? id);
        IEnumerable<ResultDTO> GetResults(Predicate<ResultDTO> predic);
        void AddResult(ResultDTO testDTO);
        void UpdateResult(ResultDTO testDTO);
        void DeleteResult(int? id);
        void Dispose();
    }
}
