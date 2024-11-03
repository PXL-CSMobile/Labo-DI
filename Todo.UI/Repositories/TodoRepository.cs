using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.UI.Models;

namespace Todo.UI.Repositories
{
    public class TodoRepository
    {
        // Create fake data using Bogus data generator:
        // https://github.com/bchavez/Bogus
        private Faker<TodoItem> fake = new Faker<TodoItem>()
            .RuleFor(todo => todo.Title, (f, todo) => f.Lorem.Word())
            .RuleFor(todo => todo.Description, (f, todo) => f.Lorem.Sentence())
            .RuleFor(todo => todo.IsCompleted, (f, todo) => f.Random.Bool())
            .RuleFor(todo => todo.DueDate, (f, todo) => f.Date.Soon(7));

        public async Task<List<TodoItem>> GetTodoItems(int numberOfItems)
        {
            List<TodoItem> items = new List<TodoItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                items.Add(fake.Generate());
                await Task.Delay(10);
            }

            return items;
        }
    }
}
