using System;

namespace DiffedData.Domain.Entities
{
    public class DataCommand
    {
        public string Id { get; private set; }
        public string BodyData { get; private set; }
        public bool IsLeft { get; private set; }

        public DataCommand(string id, string bodyData, string action)
        {
            if (!IsValid(action))
                throw new ArgumentException("Parameter Invalid: must be left or right");

            Id = id;
            BodyData = bodyData;
            IsLeft = action.Equals("left", System.StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsValid(string action)
        {
            if (action.Equals("left", System.StringComparison.InvariantCultureIgnoreCase) 
                || action.Equals("right", System.StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }
    }
}