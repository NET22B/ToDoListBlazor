using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Shared
{
    public class CreateItem
    {
        [Required]
        [StringLength(5)]
        public string Text { get; set; } = string.Empty;
    }
}
