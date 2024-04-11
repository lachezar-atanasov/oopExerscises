using BoardR.Models;
using Task = BoardR.Models.Task;

namespace BoardR
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            var task = new Task("App flow tests?", "Peter", tomorrow);

            task.RevertStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.RevertStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();

            Console.WriteLine(task.ViewHistory());
        }
    }
}
