using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todoist.DTO;

namespace Todoist.Model
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool done { get; set; }

        public static Todo CreateInstance(TodoDTO todoDTO)
        {
            return new Todo
            {
                name = todoDTO.name,
                description = todoDTO.description,
                done = todoDTO.done
            };
        }
    }
}
