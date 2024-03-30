namespace AppointmentSystem.Application.DTOs
{
    public class IDTO<T> where T : class?, new()
    {
        public IDTO(int status, T? data, string? messages)
        {
            this.status = status;
            this.data = data;
            this.messages = messages;
        }
        public IDTO()
        {
        }

        public int status { get; set; }
        public T? data { get; set; }
        public string? messages { get; set; }
    }

}
