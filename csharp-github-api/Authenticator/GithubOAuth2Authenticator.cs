using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace csharp_github_api.Authenticator
{
    public class GithubOAuth2Authenticator : OAuth2Authenticator
    {
        private readonly string _authorizationValue;

        public GithubOAuth2Authenticator(string accessToken) : base(accessToken)
        {
            _authorizationValue = "token " + accessToken;
        }

        public override void Authenticate(IRestClient client, IRestRequest request)
        {
            // only add the Authorization parameter if it hasn't been added.
            if (!request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
            {
                request.AddParameter("Authorization", _authorizationValue, ParameterType.HttpHeader);
            }

        }
    }
}
