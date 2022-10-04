using System.Net.Http.Json;
using ToDoList.Shared;

namespace ToDoList.Client.Services
{
    public class ToDoClient : IToDoClient
    {
        private readonly HttpClient httpClient;

        public ToDoClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            // this.httpClient.BaseAddress
        }

        public async Task<IEnumerable<Item>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Item>>("api/todo");
        }
    }
}
