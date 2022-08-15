using Distillery.Application.TodoLists.Queries.ExportTodos;

namespace Distillery.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
