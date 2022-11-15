namespace EmailGenerator.Services
{
    public class RandomWordProvider
    {
        private const string API_URL = "https://random-word-api.herokuapp.com/word";

        private readonly IHttpClientFactory _HttpClientFactory;

        private readonly HttpClient _HttpClient;

        public RandomWordProvider(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
            _HttpClient = _HttpClientFactory.CreateClient();
        }

        public async Task<string> GetRandomWordAsync()
        {
            var word = await _HttpClient.GetStringAsync(API_URL);
            return word;
        }

        public string GetRandomWord()
        {
            return _HttpClient.GetStringAsync(API_URL).GetAwaiter().GetResult();
        }
    }
}
