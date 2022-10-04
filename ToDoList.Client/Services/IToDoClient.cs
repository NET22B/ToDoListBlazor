using ToDoList.Shared;

namespace ToDoList.Client.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Item>?> GetAsync();
    }
}