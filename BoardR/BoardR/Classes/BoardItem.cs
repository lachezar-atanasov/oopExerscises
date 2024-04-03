using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
{
    public class BoardItem
    {
        public string title;
        public DateTime dueDate;
        public Status status;
        

        public BoardItem(string title, DateTime dueDate)
        {
            bool isValidTitle = title.Length >= 5 && title.Length <= 30;
            bool isValidDate = dueDate > DateTime.Now;

            if (isValidTitle)
            {
                this.title = title;
            }

            if (isValidDate)
            {
                this.dueDate = dueDate;
            }

            status = Status.Open;
        }
        public string ViewInfo()
        {
            return $"{title}, [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }

        public void RevertStatus()
        {
            if (status == 0)
            {
                return;
            }
            status--;
        }

        public void AdvanceStatus()
        {
            bool isLastStatusElement = (int)status == Enum.GetNames(typeof(Status)).Length - 1;
            if (isLastStatusElement)
            {
                return;
            }
            status++;
        }
    }
}
