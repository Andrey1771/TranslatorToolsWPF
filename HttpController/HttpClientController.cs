using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientControllerLibrary
{
    public class HttpClientController
    {
        private const double _minTimeout = 1; // In seconds
        private const double _maxTimeout = 10000; // In seconds
        private readonly HttpClient _httpClient;

        public TimeSpan Timeout
        {
            get
            {
                return _httpClient.Timeout;
            }
            set
            {
                if (value.TotalSeconds < _minTimeout || value.TotalSeconds > _maxTimeout)
                    throw new ArgumentException($"Timeout должен быть меньше {_minTimeout} и больше {_maxTimeout}");

                _httpClient.Timeout = value;
            }
        }

        public Uri DefaultRequestUri { get; set; }
        public bool AuthorizationEnabled { get; set; }
        public string AuthorizationKey { get; private set; }
        public string AuthorizationValue { get; private set; }

        public HttpClientController()
        {
            _httpClient = new HttpClient();
            Timeout = new TimeSpan(0, 0, 30);
            DefaultRequestUri = new Uri(/*"https://jsonplaceholder.typicode.com/todos"*/"http://tmgwebtest.azurewebsites.net/api/textstrings/2");
            //AuthorizationEnabled = false;
            AuthorizationEnabled = true;
            SetAuthorizationSettings("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");
        }

        public void SetAuthorizationSettings(string key, string value)
        {
            AuthorizationKey = key;
            AuthorizationValue = value;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri? uri = null)
        {
            if (uri == null)
                uri = DefaultRequestUri;
            var httpResponse = new HttpResponseMessage();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);

            try
            {
                if (AuthorizationEnabled)
                {
                    httpRequest.Headers.Add(AuthorizationKey, AuthorizationValue);
                    httpResponse = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
                }
                else
                {
                    httpResponse = await _httpClient.GetAsync(uri).ConfigureAwait(false);
                }

                httpResponse.EnsureSuccessStatusCode();//Todo в лог httpResponse.EnsureSuccessStatusCode().StatusCode
                //Log.Logger.Information()
                var res = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                var error = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                //Log.Logger.Information()
            }
            return httpResponse;
        }
    }
}
