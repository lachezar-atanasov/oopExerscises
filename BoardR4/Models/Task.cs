namespace BoardR.Models
{
    public class Task: BoardItem
    {
        private string _assignee;

        public Task(string title, string assignee, DateTime dueDate)
            :base(title,dueDate, Status.Todo)
        {
            Assignee = assignee;
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
        protected override void LogOnCreate()
        {
            base.AddEventLog($"Created Task: '{this.ViewInfo()}'");
        }
    }
}
