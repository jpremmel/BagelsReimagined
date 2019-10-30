using System.Threading.Tasks;
using RestSharp;

namespace BagelsR.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall(string controller)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/{controller}");
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}