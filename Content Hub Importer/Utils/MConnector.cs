using Stylelabs.M.Sdk.WebClient;
using System;

namespace ContentHub.Importer.Utils
{
    public static class MConnector
    {
        private static Lazy<IWebMClient> _client { get; set; }

        public static IWebMClient Client
        {
            get
            {
                if (_client == null)
                {
                    var auth = new Stylelabs.M.Sdk.WebClient.Authentication.OAuthPasswordGrant()
                    {
                        ClientId = "SitecoreConnect",
                        ClientSecret = "SitecoreConnect",
                        UserName = "asmita.parkar",
                        Password = "Asmitaaltudo@5505"
                    };

                    System.Uri SampleURL = new Uri("https://chtraining.sitecoresandbox.cloud/");
                    _client = new Lazy<IWebMClient>(() => MClientFactory.CreateMClient(SampleURL, auth));
                    IWebMClient client = MClientFactory.CreateMClient(SampleURL, auth);
                    client.TestConnectionAsync().Wait();
                }

                return _client.Value;
            }
        }
    }
}
