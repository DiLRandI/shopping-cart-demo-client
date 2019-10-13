using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace shopping_cart_demo_client.Data
{
    public class ItemService
    {
        private readonly HttpClient client;
        private readonly string endpoint;

        public ItemService(HttpClient httpClient)
        {
            this.client = httpClient;
            endpoint = Environment.GetEnvironmentVariable(Config.ITEMS_ENDPOINT);
            if(endpoint == null)
            {
                throw new  ArgumentException("Item endpint value is not provided");
            }
        }

        public async Task<string> GetAllEmployeesAsync()
        {
            var res = await client.GetStreamAsync(endpoint);
            string s = "";
            System.Console.WriteLine(res);
            return s;
        }
    }
}