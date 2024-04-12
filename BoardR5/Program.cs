using BoardR.Models;
using BoardR4;
using Task = BoardR.Models.Task;

namespace BoardR
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            var task = new Task("Write unit tests", "Peter", tomorrow);
            var issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

            Board.AddItem(task);
            Board.AddItem(issue);
            task.AdvanceStatus();
            issue.AdvanceStatus();

            Board.LogHistory();
        }
    }
}
