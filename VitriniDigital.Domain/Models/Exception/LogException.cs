namespace VitriniDigital.Domain.Models.Exception
{
    public sealed class LogException
    {
        public LogException(string endpoint, string messageError)
        {
            Endpoint = endpoint;
            MessageError = messageError;
        }

        public string Endpoint { get; set; }
        public string MessageError { get; set; }
    }
}
