using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using csharp_github_api.Models;
using csharp_github_api.Api.Authorizations;

namespace csharp_github_api.GetAuthToken
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new GithubRestApiClient( @"https://api.github.com");
            client.WithAuthentication(new HttpBasicAuthenticator("[user name here]", "[password here]"));

            CreateAuthorization(client);
            //GetAuthorizations(client);
        }

        private static void CreateAuthorization(GithubRestApiClient client)
        {
            var response = client.CreateAuthorization<Authorization>(new List<string> { "repo" }, "[client id here]",
                                                                     "[client secret here]");

            Console.WriteLine("Authorization Token: " + response.Data.Token);
            Console.ReadKey();
        }

        private static void GetAuthorizations(GithubRestApiClient client)
        {
            var response = client.GetAuthorizations<List<Authorization>>();

            foreach (var auth in response.Data)
            {
                Console.WriteLine("App: " + auth.App.Name);
                Console.WriteLine("Authorization Token: " + auth.Token);
                Console.WriteLine(Environment.NewLine);
            }

            Console.ReadKey();
        }
    }
}
