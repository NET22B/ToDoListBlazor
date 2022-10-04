using ToDoList.Shared;

namespace ToDoList.Client.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Item>?> GetAsync();
        Task<Item?> PostAsync(CreateItem createItem);
    }
}