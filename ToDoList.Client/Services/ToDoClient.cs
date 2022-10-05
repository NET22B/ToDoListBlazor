using System.Net;
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
        
        public async Task<Item?> PostAsync(CreateItem createItem)
        {
            var response =  await httpClient.PostAsJsonAsync<CreateItem>("api/todo", createItem);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Item>();

            return null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var response = await httpClient.DeleteAsync($"api/todo/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }
        
        public async Task<bool> EditAsync(Item item)
        {
            var response = await httpClient.PutAsJsonAsync($"api/todo/{item.Id}", item);

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
