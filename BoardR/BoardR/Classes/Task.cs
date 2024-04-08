using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
{
    public class Task: BoardItem
    {
        private string title;
        private string assignee;
        public string Title { get; set; }
        public string Assignee
        {
            get => assignee;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Asignee must not be null or empty! ");
                }
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Asignee must be between 5 and 30 characters! ");
                }
                if (!(assignee==null))
                {
                    base.AddLog($"Assignee changed: from {assignee} to {value}");
                }
                assignee = value;
            }
        }
        public DateTime DueDate { get; set; }

        public Task(string title, string assignee, DateTime dueDate):base(title,dueDate, Status.Todo)
        {
            Title = title;
            Assignee = assignee; 
            DueDate = dueDate;
            base.AddLog($"Created Task: '{this.ViewInfo()}'");
        }
    }
}
