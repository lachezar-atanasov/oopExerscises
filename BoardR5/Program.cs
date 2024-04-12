using BoardR.Models;
using BoardR4;
using BoardR4.Models.Abstract;
using BoardR5.Loggers;
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
            Console.WriteLine(task.ViewInfo());
            Console.WriteLine(issue.ViewInfo());
        }
    }
}
