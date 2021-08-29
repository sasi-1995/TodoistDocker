using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todoist.Model;

namespace Todoist.Repository
{
    public class TodoistRepository: DbContext
    {
        public TodoistRepository(DbContextOptions options): base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
