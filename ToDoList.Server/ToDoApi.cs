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

namespace ToDoList.Server
{
    public static class ToDoApi
    {
        [FunctionName("GetTodos")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "todo")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var items = GetItems();

            return new OkObjectResult(items);
        } 
        
        [FunctionName("CreateTodos")]
        public static async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post",  Route = "todo")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createItem = JsonConvert.DeserializeObject<CreateItem>(requestBody);

            if (createItem == null || string.IsNullOrWhiteSpace(createItem.Text)) return new BadRequestResult();

            var item = new Item { Text = createItem.Text };

            return new OkObjectResult(item);
        }

        private static IEnumerable<Item> GetItems()
        {
            return new List<Item>()
            {
                new Item()
                {
                    Text = "Banan"
                },
                new Item()
                {
                    Text = "Apelsin"
                },
                new Item()
                {
                    Text = "Bröd",
                    Completed = true
                },
                new Item()
                {
                    Text = "Mjölk"
                }
            };
        }
    }
}
