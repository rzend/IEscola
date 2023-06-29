namespace IEscola.Api
{
    public class Settings : ISettings
    {
        public string Secret { get; set; }
        public string MyApiKey { get; set; }
    }

    public interface ISettings
    {
        public string Secret { get; set; }
        public string MyApiKey { get; set; }
    }

}
