using BoardR4.Models.Abstract;

namespace BoardR.Models
{
    public class Issue : BoardItem
    {
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {
            Description = description ?? "No description";
            this.AddEventLog($"Created Issue: {this.ViewInfo()}. Description: {Description}");
        }
        public string Description { get; }
        public override string ViewInfo()
        {
            var baseInfo = base.ViewInfo();
            baseInfo += " Description: " + Description;
            // output info about the Type, the baseInfo, the Assignee
            return baseInfo;
        }
        public override void RevertStatus()
        {
            if (Status == Status.Open)
            {
                this.AddEventLog($"Issue status already {Status}");
                return;
            }
            Status = Status.Open;
            this.AddEventLog($"Issue status set to {Status.Open}");
        }
        public override void AdvanceStatus()
        {
            if (Status == Status.Verified)
            {
                this.AddEventLog($"Issue status already {Status}");
                return;
            }
            Status = Status.Verified;
            this.AddEventLog($"Issue status set to {Status.Verified}");
        }
    }
}
