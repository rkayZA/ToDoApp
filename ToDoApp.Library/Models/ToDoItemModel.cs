using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Library.Models
{
    public  class ToDoItemModel
    {
        public int Id { get; set; }
        public string DateAdded { get; set; }
        public string ToDoItem { get; set; }
        public bool IsCompleted { get; set; } = false;
      
     
    }
}
