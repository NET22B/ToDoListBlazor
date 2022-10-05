//using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Server.Entitys
{
    public class ItemTableEntity : TableEntity
    {
        public string Text { get; set; }
        public bool Completed { get; set; }
    }
}
