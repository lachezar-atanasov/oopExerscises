using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
{
    public class Issue : BoardItem
    {
        private string description;
        public Issue(string title, string description, DateTime dueDate) : base(title, dueDate, Status.Open)
        {
            Description = description;
            base.AddLog($"Created Issue: '{this.ViewInfo()}. Description: {this.description}'");
        }
        public string Description
        {
            get => description;
            private set
            {
                if (value == null) 
                {
                    description = "No description";
                }
                else
                {
                    description = value;
                }
            }
        }
    }
}
