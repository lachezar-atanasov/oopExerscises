using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPractice.Classes
{
    public class ForumPost
    {
        public string author;
        public string text;
        public int upvotes;
        public List<string> replies = new List<string>();
        public ForumPost(string author, string text)
        {
            this.author = author;
            this.text = text;
        }
        public ForumPost(string author, string text, int upvotes):this(author,text)
        {
            this.upvotes = upvotes;
        }
        public string Format()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.text} / by {this.author}, {this.upvotes} upvotes");
            foreach( var reply in replies )
            {
                sb.AppendLine($"- {reply}");
            }
            return sb.ToString();
        }
    }
}
