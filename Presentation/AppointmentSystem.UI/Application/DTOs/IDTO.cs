namespace AppointmentSystem.UI.Application.DTOs
{
    public class IDTO<T> where T : class?, new()
    {
        public int status { get; set; }
        public T? data { get; set; }
        public string? messages { get; set; }
    }
}
