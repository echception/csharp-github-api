using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace csharp_github_api.Authenticator
{
    public class GithubOAuth2Authenticator : OAuth2Authenticator
    {
        public GithubOAuth2Authenticator(string accessToken) : base(accessToken)
        {
            
        }

        public override void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddParameter("access_token", AccessToken, ParameterType.GetOrPost);
        }
    }
}
