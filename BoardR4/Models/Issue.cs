namespace BoardR.Models
{
    public class Issue : BoardItem
    {
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {
            Description = description ?? "No description";
        }
        protected override void LogOnCreate()
        {
            base.AddEventLog($"Created Issue: '{this.ViewInfo()}. Description: {Description}'");
        }
        public string Description { get; }
    }
}
