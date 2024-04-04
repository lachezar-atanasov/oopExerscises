using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
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
