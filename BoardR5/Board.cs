using BoardR4.Loggers;
using BoardR4.Models.Abstract;

namespace BoardR4
{
    public static class Board
    {
        private static List<BoardItem> items = new List<BoardItem>();
        private static readonly ILogger logger;
        public static int TotalItems
        {
            get
            {
                return items.Count;
            }
        }
        public static void LogHistory(ILogger logger)
        {
            foreach (var item in items)
            {
                logger.Log(item.ViewHistory());
            }
        }
        public static void AddItem(BoardItem item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException("item already exists");
            }
            items.Add(item);
        }
    }
}
