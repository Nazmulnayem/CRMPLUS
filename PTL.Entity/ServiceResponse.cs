namespace PTL.Entity
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string UIMessage
        {
            get
            {
                if (IsSuccess)
                {
                    return "";
                }
                else
                {
                    return "Something went wrong. Please Contact PTL Support Team.";
                }

            }
            set { }
        }
        public string ExceptionMessage { get; set; } = "";
    }
}
