using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BoardR.Classes
{
    public class BoardItem
    {
        private string title;
        private DateTime dueDate;
        private Status status;
        private readonly List<EventLog> logs = new List<EventLog>();
        private const string dateTimeFormat = "dd-MM-yyyy";

        public BoardItem(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
            status = Status.Open;
            logs.Add(new EventLog($"Item created: '{this.ViewInfo()}'"));
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                bool isValidTitle = value.Length >= 5 && value.Length <= 30;

                if (!isValidTitle)
                {
                    throw new ArgumentException("Title must be between 5 and 30 chars.");
                }

                // set only if validated, otherwise throw ex with some meaningful message
                if (!String.IsNullOrEmpty(title))
                {
                    logs.Add(new EventLog($"{nameof(Title)} changed from '{title}' to '{value}'"));
                }
                
                this.title = value;
                
            }
        }
        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                bool isValidDate = value > DateTime.Now;

                if (!isValidDate)
                {
                    throw new ArgumentException("Date must be in the future.");
                }

                // set only if validated, otherwise throw ex with some meaningful message
                if (!(dueDate==default(DateTime)))
                {
                    logs.Add(new EventLog($"{nameof(DueDate)} changed from " +
                        $"'{dueDate.ToString(dateTimeFormat)}' to '{value.ToString(dateTimeFormat)}'"));
                }
                this.dueDate = value;
            }
        }
        public Status Status
        {
            get
            {
                // return the value of the status field
                return this.status;
            }
        }
        public string ViewInfo()
        {
            return $"{title}, [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }

        public void RevertStatus()
        {
            if (status == 0)
            {
                logs.Add(new EventLog($"Can't revert, already at {status}"));
                return;
            }
            logs.Add(new EventLog($"Status changed from {status} to {--status}"));
        }
        public void AdvanceStatus()
        {
            bool isLastStatusElement = (int)status == Enum.GetNames(typeof(Status)).Length - 1;
            if (isLastStatusElement)
            {
                logs.Add(new EventLog($"Can't advance, already at {status}"));
                return;
            }
            logs.Add(new EventLog($"Status changed from {status} to {++status}"));
        }
        public string ViewHistory()
        {
            StringBuilder sb = new StringBuilder();
            foreach (EventLog log in logs) 
            {
                sb.AppendLine(log.ViewInfo());
            }
            return sb.ToString();
        }
    }
}
