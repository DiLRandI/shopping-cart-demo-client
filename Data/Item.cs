
using Newtonsoft.Json;

namespace shopping_cart_demo_client.Data
{
    public class Item
    {
        public int Id { get; set; }
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }
        public string Description { get; set; }
        [JsonProperty("unit_price")]
        public float UnitPrice { get; set; }
        [JsonProperty("packing_details")]
        public PackageDetail PackageDetails { get; set; }
    }

    public class PackageDetail
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}