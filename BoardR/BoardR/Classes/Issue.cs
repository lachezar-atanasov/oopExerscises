using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Classes
{
    public class Issue : BoardItem
    {
        public Issue(string title, DateTime dueDate) : base(title, dueDate)
        {
        }
    }
}
