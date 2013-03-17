using System.Dynamic;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_github_api.Api.Authorizations
{
    public static class Authorizations
    {
        public static IRestResponse<T> CreateAuthorization<T>(this GithubRestApiClient client, List<string> scopes, string clientId, string clientSecret ) where T : new()
        {
            dynamic data = GetAuthorizationData(scopes, clientId, clientSecret);

            var request = client.RequestFactory.CreateRequest(
                () =>
                {
                    var req = new RestRequest("/authorizations")
                    {
                        Method = Method.POST,
                        RequestFormat = DataFormat.Json
                    };
                    req.AddBody(data);
                    return req;
                });

            var response = client.Execute<T>(request);

            return response;
        }

        public static IRestResponse<T> GetAuthorizations<T>(this GithubRestApiClient client) where T : new()
        {
            var request = client.RequestFactory.CreateRequest(() => new RestRequest("/authorizations"));

            var response = client.Execute<T>(request);

            return response;
        }

        private static dynamic GetAuthorizationData(List<string> scopes, string clientId, string clientSecret)
        {
            dynamic data = new ExpandoObject();
            data.scopes = scopes;
            data.client_id = clientId;
            data.client_secret = clientSecret;

            return data;
        }
    }
}
