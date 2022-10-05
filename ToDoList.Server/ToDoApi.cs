using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using ToDoList.Shared;
using ToDoList.Server.Entitys;
using ToDoList.Server.Extensions;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;

namespace ToDoList.Server
{
    public static class ToDoApi
    {
        [FunctionName("GetTodos")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "todo")] HttpRequest req,
            [Table("items", Connection = "AzureWebJobsStorage")] CloudTable itemTable,
            ILogger log)
        {
            log.LogInformation("Get Item");

            var query = new TableQuery<ItemTableEntity>();
            var result = await itemTable.ExecuteQuerySegmentedAsync(query, null);

            var response = result.Select(Mapper.ToItem).ToList();

            return new OkObjectResult(response);
        } 
        
        [FunctionName("CreateTodos")]
        public static async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post",  Route = "todo")] HttpRequest req,
            [Table("items", Connection = "AzureWebJobsStorage")] IAsyncCollector<ItemTableEntity> itemTable,
            ILogger log)
        {
            log.LogInformation("Create item");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createItem = JsonConvert.DeserializeObject<CreateItem>(requestBody);

            if (createItem == null || string.IsNullOrWhiteSpace(createItem.Text)) return new BadRequestResult();

            var item = new Item { Text = createItem.Text };

            await itemTable.AddAsync(item.ToTableEntity());

            return new OkObjectResult(item);
        } 
        
        [FunctionName("Delete")]
        public static async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete",  Route = "todo/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            log.LogInformation("Delete item");


            return new NoContentResult();
        }
        
        [FunctionName("EditItem")]
        public static async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put",  Route = "todo/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            log.LogInformation("Put item");


            return new NoContentResult();
        }

      
    }
}
