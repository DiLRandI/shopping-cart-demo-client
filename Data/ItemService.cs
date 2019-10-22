using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace shopping_cart_demo_client.Data
{
    public class ItemService
    {
        private readonly HttpClient client;
        private readonly string endpoint;


        public ItemService(HttpClient httpClient, IConfiguration configuration)
        {
            this.client = httpClient;
            endpoint = configuration.GetSection("ItemService:HTTP").Value;
            if (endpoint == null)
            {
                throw new ArgumentException("Item endpint value is not provided");
            }
        }

        public async Task<IList<Item>> GetAllEmployeesAsync()
        {
            var res = await client.GetAsync(endpoint + "/getitem");
            res.EnsureSuccessStatusCode();
            string responseBody = await res.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<IList<Item>>(responseBody);
            return items;
        }
    }
}