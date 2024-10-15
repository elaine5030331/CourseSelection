namespace CourseSelection.Data
{
    public class OperationResult
    {
        public OperationResult() 
        {
            IsSuccess = true;
        }
        public OperationResult(string errorMessage) 
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class OperationResult<T> : OperationResult where T : BaseOperationResult
    {
        public OperationResult() :base() { }
        public OperationResult(string errorMessage) : base(errorMessage) { }
        public OperationResult(T resultDto)
        {
            IsSuccess = true;
            ResultDto = resultDto;
        }

        public T ResultDto { get; set; }
    }

    public class BaseOperationResult
    {
    }
}
