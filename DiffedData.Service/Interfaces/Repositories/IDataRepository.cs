using DiffedData.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiffedData.Domain.Interfaces.Repositories
{
    public interface IDataRepository
    {
        Task<Dictionary<string, DataEntity>> AddData(DataEntity data);
        Task<List<DataEntity>> GetDataById(string id);
        Task<bool> LeftDataIdExist(string id);
        Task<bool> RightDataIdExist(string id);
        Task<bool> LeftAndRightDataContainsId(string id);       
    }
}
