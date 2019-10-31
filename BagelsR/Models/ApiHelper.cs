using System.Threading.Tasks;
using RestSharp;
using BagelsR.Models;

namespace BagelsR.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall(string controller, int id)
        {
            RestClient client;
            if (id != 0)
            {
                client = new RestClient($"http://localhost:5000/api/{controller}/{id}");
            }
            else
            {
                client = new RestClient($"http://localhost:5000/api/{controller}");
            }
            
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallEditBagel(Bagel bagel)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/bagels/{bagel.BagelId}");
            RestRequest request = new RestRequest("/", Method.PUT);
            request.AddJsonBody(bagel);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallCreateBagel(Bagel bagel)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/bagels");
            RestRequest request = new RestRequest("/", Method.POST);
            request.AddJsonBody(bagel);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallDeleteBagel(Bagel bagel)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/bagels/{bagel.BagelId}");
            RestRequest request = new RestRequest("/", Method.DELETE);
            request.AddJsonBody(bagel);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallEditTopping(Topping topping)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/toppings/{topping.ToppingId}");
            RestRequest request = new RestRequest("/", Method.PUT);
            request.AddJsonBody(topping);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallCreateTopping(Topping topping)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/toppings");
            RestRequest request = new RestRequest("/", Method.POST);
            request.AddJsonBody(topping);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallDeleteTopping(Topping topping)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/toppings/{topping.ToppingId}");
            RestRequest request = new RestRequest("/", Method.DELETE);
            request.AddJsonBody(topping);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}