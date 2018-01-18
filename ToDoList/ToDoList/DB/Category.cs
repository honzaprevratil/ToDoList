using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Abstract;

namespace ToDoList
{
    public class Category : ATable
    {
        public string Name { get; set; }
        public Category()
        {
        }
        public override string ToString()
        {
            return "ID" + ID + " Category " + Name;
        }
    }
}
