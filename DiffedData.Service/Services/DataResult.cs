namespace DiffedData.Domain.Services
{
    public class DataResult<T>
    {
        public bool IsValid { get; set; }
        public T Value {get;set;}
        public string Message { get; set; }
        public string Diff { get; set; }


        public  static DataResult<T> Ok(T value, string message)
        {
            return new DataResult<T>
            {
                IsValid = true,
                Value = value,
                Message = message
            };
        }

        public static DataResult<T> Fail(string diff, string message)
        {
            return new DataResult<T>
            {
                IsValid = false,
                Diff = diff,
                Message = message
            };
        }

        public  static DataResult<T> Fail(string message)
        {
            return new DataResult<T>
            {
                IsValid = false,
                Message = message
            };
        }        

    }
}