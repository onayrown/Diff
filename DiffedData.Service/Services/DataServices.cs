using DiffedData.Domain.Entities;
using DiffedData.Domain.Interfaces.Repositories;
using DiffedData.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffedData.Domain.Services
{
    public class DataServices : IDataServices
    {
        private readonly IDataRepository _dataRepository;

        public DataServices(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<DataResult<Dictionary<string, DataEntity>>> AddData(DataCommand command)
        {

            var data = DataEntity.Create(command);

            if (data.IsLeft)
            {
                if (await LeftDataIsValid(data.Id))
                    return DataResult<Dictionary<string, DataEntity>>.Fail("Error: Id already exist on left data.");
            }
            else
            {
                if (await RightDataIsValid(data.Id))
                    return DataResult<Dictionary<string, DataEntity>>.Fail("Error: Id already exist on right data.");
            }


            if (data.IsValid())
                return DataResult<Dictionary<string, DataEntity>>.Ok(await _dataRepository.AddData(data), "data successfully added.");
            else
                return DataResult<Dictionary<string, DataEntity>>.Fail("Error: internal error.");
        }

        public async Task<DataResult<Dictionary<string, DataEntity>>> Compare(string id)
        {
            if (!await RightIdAndLeftIdAreValid(id))
                return DataResult<Dictionary<string, DataEntity>>.Fail("Error: the same Id is not present on the left and right data."); 

            var diffs = await _dataRepository.GetDataById(id);

            var dataLeft = diffs[0];
            var dataRight = diffs[1];

            if (!dataLeft.BodyData.Equals(dataRight.BodyData))
            {
                if (dataLeft.BodyData.Length != dataRight.BodyData.Length)
                    return DataResult<Dictionary<string, DataEntity>>.Fail("data are not equal in size and content.");
                else
                {
                    var result = OffSetDiff(id, dataLeft.BodyData, dataRight.BodyData);
                    return DataResult<Dictionary<string, DataEntity>>.Fail(result, "data are equal in size but not in content.");
                }
            }

            var dataResult = new Dictionary<string, DataEntity>
                {
                    { id, dataLeft }
                };

            return DataResult<Dictionary<string, DataEntity>>.Ok(dataResult, "data are equal in size and content.");

        }

        public string OffSetDiff(string id, string bodyLeft, string bodyRight)
        {
            char[] diffCharArrLeft = new char[bodyLeft.Count()];
            char[] diffCharArrRight = new char[bodyRight.Count()];
            for (int i = 0; i < bodyLeft.Count(); i++)
            {
                for (int j = 0; j < bodyRight.Count(); j++)
                {
                    if (bodyLeft.Count() == bodyRight.Count())
                    {
                        if (bodyLeft[i] != bodyRight[i])
                        {
                            diffCharArrLeft[i] = bodyLeft[i];
                            diffCharArrRight[i] = bodyRight[i];
                        }
                    }
                }
            }

            string diffStrLeft = new string(diffCharArrLeft);
            string diffStrRight = new string(diffCharArrRight);

            StringBuilder result = new StringBuilder("Left Data Diff: ");
            result.Append(diffStrLeft);
            result.Append(" and Right Data Diff: ");
            result.Append(diffStrRight);

            return result.ToString();
        }

        public async Task<bool> LeftDataIsValid(string id)
        {
            return await _dataRepository.LeftDataIdExist(id);
        }

        public async Task<bool> RightDataIsValid(string id)
        {
            return await _dataRepository.RightDataIdExist(id);
        }

        public async Task<bool> RightIdAndLeftIdAreValid(string id)
        {
            return await _dataRepository.LeftAndRightDataContainsId(id);
        }
    }
}
