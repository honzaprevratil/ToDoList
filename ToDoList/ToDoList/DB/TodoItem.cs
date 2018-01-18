using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Abstract;

namespace ToDoList
{
    public class TodoItem : ATable
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public int CategoryID { get; set; }
        public TodoItem()
        {
        }
        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Text;
        }
    }
}
