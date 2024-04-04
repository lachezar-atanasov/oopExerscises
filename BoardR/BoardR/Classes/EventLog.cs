using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
{
    public class EventLog
    {
        private readonly string description;
        private readonly DateTime time;

        public EventLog(string description)
        {
            if (String.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description must not be null or empty. ");
            }
            this.description = description;


            this.time = DateTime.Now;
        }
        public string Description
        {
            get
            {
                return description;
            }
        }
        public DateTime Time
        {
            get
            {
                return time;
            }
        }

        public string ViewInfo()
        {
            return $"[{Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{Description}";
        }
    }
}
