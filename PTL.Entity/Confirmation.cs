namespace PTL.Entity
{
    public class Confirmation
    {
        public string? title { get; set; }
        public string? text { get; set; }
        public AlertIcons icon { get; set; }
    }
    public enum AlertIcons
    {
        success,
        warning,
        error,
        info
    }
}
