﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("n");
        public string Text { get; set; } = string.Empty;
        public bool  Completed { get; set; }
    }
}
