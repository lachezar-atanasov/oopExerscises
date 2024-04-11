using BoardR4.Models.Abstract;

namespace BoardR.Models
{
    public class Task : BoardItem
    {
        private string _assignee;

        public Task(string title, string assignee, DateTime dueDate)
            :base(title,dueDate, Status.Todo)
        {
            Assignee = assignee;
            this.AddEventLog($"Created Task: '{this.ViewInfo()}'");
        }
        public string Assignee
        {
            get => _assignee;
            set
            {
                EnsureValidAssignee(value);
                if (!(_assignee == null))
                {
                    base.AddEventLog($"Assignee changed: from {_assignee} to {value}");
                }
                _assignee = value;
            }
        }

        public override void RevertStatus()
        {
            if (Status == Status.Todo)
            {
                this.AddEventLog($"Task status already {Status}");
                return;
            }
            this.AddEventLog($"Task changed from {Status} to {--Status}");
        }
        public override void AdvanceStatus()
        {
            bool isLastStatusElement = (int)Status == Enum.GetNames(typeof(Status)).Length - 1;
            if (isLastStatusElement)
            {
                this.AddEventLog($"Task status already {Status}");
                return;
            }
            this.AddEventLog($"Task changed from {Status} to {++Status}");
        }

        private void EnsureValidAssignee(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Asignee must not be null or empty! ");
            }
            if (value.Length < 5 || value.Length > 30)
            {
                throw new ArgumentException("Asignee must be between 5 and 30 characters! ");
            }
        }
    }
}
