using DiffedData.Domain.Entities;
using DiffedData.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiffedData.Domain.Interfaces.Services
{
    public interface IDataServices
    {
        Task<DataResult<Dictionary<string, DataEntity>>> AddData(DataCommand command);
        Task<DataResult<Dictionary<string, DataEntity>>> Compare(string id);
    }
}
