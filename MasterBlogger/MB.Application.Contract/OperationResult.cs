namespace MB.Application.Contracts
{
    public class OperationResult
    {
        public bool IsSucceeded { get; private set; }

        public string Message { get; private set; } = string.Empty;

        public OperationResult Succeeded(string message)
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}
