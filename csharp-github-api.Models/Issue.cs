using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_github_api.Models
{
    public class IssueUser
    {
        public virtual string Login { get; set; }
        public virtual int Id { get; set; }
        public virtual string AvatarUrl { get; set; }
        public virtual string GravatarUrl { get; set; }
        public virtual string Url { get; set; }
    }

    public class Label
    {
        public virtual string Url { get; set; }
        public virtual string Name { get; set; }
        public virtual string Color { get; set; }
    }

    public class Milestone
    {
        public virtual string Url { get; set; }
        public virtual int Number { get; set; }
        public virtual string State { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual IssueUser Creator { get; set; }
        public virtual int OpenIssues { get; set; }
        public virtual int ClosedIssues { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime DueOn { get; set; }
    }

    public class PullRequest
    {
        public virtual string HtmlUrl { get; set; }
        public virtual string DiffUrl { get; set; }
        public virtual string PatchUrl { get; set; }
    }

    public class Issue
    {
        public virtual string Url { get; set; }
        public virtual string HtmlUrl { get; set; }
        public virtual int Number { get; set; }
        public virtual string State { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual IssueUser User { get; set; }
        public virtual List<Label> Labels { get; set; }
        public virtual IssueUser Assignee { get; set; }
        public virtual Milestone Milestone { get; set; }
        public virtual int Comments { get; set; }
        public virtual PullRequest PullRequest { get; set; }
        public virtual DateTime ClosedAt { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
