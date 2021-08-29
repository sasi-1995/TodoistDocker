using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todoist.DTO
{
    public class TodoDTO
    {
        public string name { get; set; }

        public string description { get; set; }

        public bool done { get; set; }
    }
}
