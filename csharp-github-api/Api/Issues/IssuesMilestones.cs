//-----------------------------------------------------------------------
// <copyright file="IssuesMilestones.cs" company="TemporalCohesion.co.uk">
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

using RestSharp;
namespace csharp_github_api.Api.Issues
{
    public static class IssuesMilestones
    {
        public static IRestResponse<T> GetMilestonesForRepository<T>(this GithubRestApiClient client, string owner, string repository) where T : new()
        {
            var request = client.RequestFactory.CreateRequest(
                () =>
                {
                    var req = new RestRequest("/repos/{owner}/{repo}/milestones")
                    {
                        Method = Method.GET,
                    };
                    req.AddUrlSegment("owner", owner);
                    req.AddUrlSegment("repo", repository);
                    return req;
                });

            var response = client.Execute<T>(request);

            return response;
        }
    }
}
