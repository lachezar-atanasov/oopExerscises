using BoardR4.Models.Abstract;

namespace BoardR4
{
    public static class Board
    {
        private static List<BoardItem> items = new List<BoardItem>();
        public static int TotalItems
        {
            get
            {
                return items.Count;
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
