using System;

namespace BoardR
{
    public class Program
    {
        static void Main(string[] args)
        {
            var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
            item.AdvanceStatus();
            var anotherItem = new BoardItem("Encrypt user data", DateTime.Now.AddDays(10));

            Board.items.Add(item);
            Board.items.Add(anotherItem);

            foreach (var boardItem in Board.items)
            {
                boardItem.AdvanceStatus();
            }

            foreach (var boardItem in Board.items)
            {
                Console.WriteLine(boardItem.ViewInfo());
            }
        }
    }

    public enum Status
    {
        Open,
        Todo,
        InProgress,
        Done,
        Verified
    }

    public class BoardItem
    {
        public string title;
        public DateTime dueDate;
        public Status status;

        public BoardItem(string title, DateTime dueDate)
        {
            bool isValidTitle = (title.Length >= 5 && title.Length <= 30);
            bool isValidDate = (dueDate > DateTime.Now);
            if (isValidTitle)
            {
                this.title = title;
            }
            if (isValidDate)
            {
                this.dueDate = dueDate;
            }
            this.status = Status.Open;
        }
        public string ViewInfo()
        {
            return $"{title}, [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }

        public void RevertStatus()
        {
            if (status==0)
            {
                return;
            }
            status--;
        }

        public void AdvanceStatus()
        {
            if ((int)status == Enum.GetNames(typeof(Status)).Length-1)
            {
                return;
            }
            status++;
        }
    }

    public class Board
    {
        public static List<BoardItem> items = new List<BoardItem>();
       
    }
}
