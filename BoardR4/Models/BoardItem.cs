using System.Text;

namespace BoardR.Models
{
    public abstract class BoardItem
    {
        private const string DateTimeFormat = "dd-MM-yyyy";
        private string _title;
        private DateTime _dueDate;
        private readonly List<EventLog> _eventLog = new List<EventLog>();
        
        public BoardItem(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
            Status = Status.Open;
            LogOnCreate();
        }
        public BoardItem(string title, DateTime dueDate,Status status) :this(title, dueDate)
        {
            Status = status;
        }
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                EnsureValidTitle(value);

                if (!String.IsNullOrEmpty(_title))
                {
                    _eventLog.Add(new EventLog($"{nameof(Title)} changed from '{_title}' to '{value}'"));
                }
                
                this._title = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return this._dueDate;
            }
            set
            {
                EnsureValidDueDate(value);

                if (!(_dueDate==default(DateTime)))
                {
                    _eventLog.Add(new EventLog($"{nameof(DueDate)} changed from " +
                        $"'{_dueDate.ToString(DateTimeFormat)}' to '{value.ToString(DateTimeFormat)}'"));
                }
                this._dueDate = value;
            }
        }
        public Status Status
        {
            get; protected set;
        }

        protected abstract void LogOnCreate();
        public string ViewInfo()
        {
            return $"{_title}, [{Status}|{_dueDate.ToString("dd-MM-yyyy")}]";
        }

        public void RevertStatus()
        {
            if (Status == 0)
            {
                _eventLog.Add(new EventLog($"Can't revert, already at {Status}"));
                return;
            }
            _eventLog.Add(new EventLog($"Status changed from {Status} to {--Status}"));
        }
        public void AdvanceStatus()
        {
            bool isLastStatusElement = (int)Status == Enum.GetNames(typeof(Status)).Length - 1;
            if (isLastStatusElement)
            {
                _eventLog.Add(new EventLog($"Can't advance, already at {Status}"));
                return;
            }
            _eventLog.Add(new EventLog($"Status changed from {Status} to {++Status}"));
        }
        public void AddEventLog(string message)
        {
            _eventLog.Add(new EventLog(message));
        }
        public string ViewHistory()
        {
            StringBuilder sb = new StringBuilder();
            foreach (EventLog log in _eventLog) 
            {
                sb.AppendLine(log.ViewInfo());
            }
            return sb.ToString();
        }
        private void EnsureValidDueDate(DateTime value)
        {
            bool isValidDate = value > DateTime.Now;

            if (!isValidDate)
            {
                throw new ArgumentException("Date must be in the future.");
            }
        }
        private void EnsureValidTitle(string value)
        {
            bool isValidTitle = value.Length >= 5 && value.Length <= 30;

            if (!isValidTitle)
            {
                throw new ArgumentException("Title must be between 5 and 30 chars.");
            }
        }
    }
}
