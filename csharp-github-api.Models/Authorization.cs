using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_github_api.Models
{
    public class App
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public class Authorization
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<string> Scopes { get; set; }
        public String Token { get; set; }
        public App App { get; set; }
        public string Note { get; set; }
        public string NoteUrl { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
