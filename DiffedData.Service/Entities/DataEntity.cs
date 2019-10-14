
namespace DiffedData.Domain.Entities
{
    public partial class DataEntity
    {
        private DataEntity(string id, string bodyData, bool isLeft)
        {
            this.Id = id;
            this.BodyData = bodyData;
            this.IsLeft = isLeft;
        }

        public string Id { get; private set; }
        public string BodyData { get; private set; }
        public bool IsLeft { get; private set; }

        public bool IsValid()
        {
            // Testes Is Valid Required Id and BodyData
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(BodyData))
                return false;            
            return true;
        }
    }

    public partial class DataEntity
    {
        public static DataEntity Create(DataCommand command) =>
             new DataEntity(command.Id, command.BodyData, command.IsLeft);

    }
}
