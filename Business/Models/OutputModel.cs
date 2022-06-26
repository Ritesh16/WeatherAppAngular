namespace Business.Models
{
    public class OutputModel<T>
    {
        public bool Status { get; set; }
        public T Output { get; set; }
        public string Message { get; set; }
    }
}
