using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
{
    public class EventLog
    { 
        private DateTime time;
        private string description;
        
        public EventLog(string description)
        {
            Description = description;
            Time = DateTime.Now;
        }
        public string Description
        {
            get
            {
                return description;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description must not be null or empty. ");
                }
                this.description = value;
            }
        }
        public DateTime Time
        {
            get
            {
                return time;
            }
            private set
            {
                this.time = value;
            }
        }

        public string ViewInfo()
        {
            return $"[{Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{Description}";
        }
    }
}
