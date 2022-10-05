using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Server.Entitys;
using ToDoList.Shared;

namespace ToDoList.Server.Extensions
{
    public static class Mapper
    {
        public static ItemTableEntity ToTableEntity(this Item item)
        {
            return new ItemTableEntity
            {
                Completed = item.Completed,
                Text = item.Text,
                PartitionKey = "Todo",
                RowKey = item.Id
            };
        }

        public static Item ToItem(this ItemTableEntity itemTable)
        {
            return new Item
            {
                Id = itemTable.RowKey,
                Text = itemTable.Text,
                Completed = itemTable.Completed
            };
        }
    }
}
