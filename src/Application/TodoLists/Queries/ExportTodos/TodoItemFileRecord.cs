using Distillery.Application.Common.Mappings;
using Distillery.Domain.Entities;

namespace Distillery.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
