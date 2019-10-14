using DiffedData.Data.Repositories;
using DiffedData.Domain.Entities;
using DiffedData.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiffedData.Tests.UnitTests.Mocks
{
    public class FakeDataRepository : IDataRepository
    {
        static FakeDataRepository()
        {
            leftData = new Dictionary<string, DataEntity>();
            rightData = new Dictionary<string, DataEntity>();
        }

        public static Dictionary<string, DataEntity> leftData { get; private set; }
        public static Dictionary<string, DataEntity> rightData { get; private set; }

        public async Task<Dictionary<string, DataEntity>> AddData(DataEntity data)
        {
            if (data.IsLeft)
            {
                leftData.Add(data.Id, data);
                return await Task.FromResult(leftData);
            }
            else
            {
                rightData.Add(data.Id, data);
                return await Task.FromResult(rightData);
            }
        }

        public async Task<List<DataEntity>> GetDataById(string id)
        {
            return await Task.FromResult(new List<DataEntity>
            {
                FakeDataRepository.leftData[id],
                FakeDataRepository.rightData[id]
            });
        }

        public async Task<bool> LeftAndRightDataContainsId(string id)
        {
            return await Task.FromResult(leftData.ContainsKey(id) && rightData.ContainsKey(id));
        }

        public async Task<bool> LeftDataIdExist(string id)
        {
            return await Task.FromResult(leftData.ContainsKey(id));
        }

        public async Task<bool> RightDataIdExist(string id)
        {
            return await Task.FromResult(rightData.ContainsKey(id));
        }
    }
}
