using System.Text;
using BoardR.Models;

namespace BoardR4.Models.Abstract
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
        }
        public BoardItem(string title, DateTime dueDate, Status status) 
            : this(title, dueDate)
        {
            Status = status;
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                EnsureValidTitle(value);

                if (!string.IsNullOrEmpty(_title))
                {
                    _eventLog.Add(new EventLog($"{nameof(Title)} changed from '{_title}' to '{value}'"));
                }

                _title = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                EnsureValidDueDate(value);

                if (!(_dueDate == default))
                {
                    _eventLog.Add(new EventLog($"{nameof(DueDate)} changed from " +
                        $"'{_dueDate.ToString(DateTimeFormat)}' to '{value.ToString(DateTimeFormat)}'"));
                }
                _dueDate = value;
            }
        }
        public Status Status
        {
            get; protected set;
        }
        public string ViewInfo()
        {
            return $"'{_title}', [{Status}|{_dueDate.ToString("dd-MM-yyyy")}]";
        }
        public abstract void RevertStatus();
        public abstract void AdvanceStatus();
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
