//-----------------------------------------------------------------------
// <copyright file="Issues.cs" company="TemporalCohesion.co.uk">
//     Copyright 2012 - Present Stuart Grassie
//
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.
// </copyright>
//----------------------------------------------------------------------

using System.Collections.Generic;
using System.Dynamic;
using LoggingExtensions.Logging;
using RestSharp;
namespace csharp_github_api.Api.Issues
{
    public static class Issues
    {
        public static IRestResponse<T> GetIssues<T>(this GithubRestApiClient client) where T : new()
        {
            var request = client.RequestFactory.CreateRequest(() => new RestRequest("/issues"));

            var response = client.Execute<T>(request);

            return response;
        }

        public static IRestResponse<T> CreateIssue<T>(this GithubRestApiClient client, string owner, string repository, string title, string body,
                                                      string label, int? milestone = null) where T : new()
        {
            dynamic data = GetIssueData(title, body, label, milestone);

            var request = client.RequestFactory.CreateRequest(
                () =>
                {
                    var req = new RestRequest("/repos/{owner}/{repo}/issues")
                    {
                        Method = Method.POST,
                        RequestFormat = DataFormat.Json
                    };
                    req.AddHeader("Content-Type", @"application/x-www-form-urlencoded");
                    req.AddUrlSegment("owner", owner);
                    req.AddUrlSegment("repo", repository);
                    req.AddBody(data);
                    return req;
                });

            request.RequestFormat = DataFormat.Json;
            request.Method = Method.POST;

            var response = client.Execute<T>(request);

            return response;
        }

        private static dynamic GetIssueData(string title, string body, string label, int? milestone)
        {
            dynamic data = new ExpandoObject();
            data.title = title;
            data.body = body;
            data.labels = new List<string> {label};

            if (milestone.HasValue)
            {
                data.milestone = milestone;
            }

            return data;
        }
    }
}
