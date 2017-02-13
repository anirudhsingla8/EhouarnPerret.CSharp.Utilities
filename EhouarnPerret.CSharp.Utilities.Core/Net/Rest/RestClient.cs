namespace EhouarnPerret.CSharp.Utilities.Core.Net.Rest
{
    public class RestClient
    {
        public RestClient(string baseUri)
        {
            BaseUri = baseUri;
        }
        public string BaseUri { get; }
    }
}