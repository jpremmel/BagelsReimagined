using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace BagelsR.Models
{
    public class Topping
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }

        public static List<Topping> GetToppings()
        {
            var apiCallTask = ApiHelper.ApiCall("toppings", 0);
            var result = apiCallTask.Result;
            Console.WriteLine(result.GetType());

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Topping> toppingList = JsonConvert.DeserializeObject<List<Topping>>(jsonResponse.ToString());

            return toppingList;
        }

        public static Topping GetTopping(int id)
        {
            var apiCallTask = ApiHelper.ApiCall("toppings", id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Topping topping = JsonConvert.DeserializeObject<Topping>(jsonResponse.ToString());

            return topping;
        }

        public static async Task<int> EditTopping(Topping topping)
        {
            var apiCallTask = await ApiHelper.ApiCallEditTopping(topping);
            return topping.ToppingId;
        }

        public static async Task<int> CreateTopping(Topping topping)
        {
            var apiCallTask = await ApiHelper.ApiCallCreateTopping(topping);
            return topping.ToppingId;
        }

        public static async Task<int> DeleteTopping(Topping topping)
        {
            var apiCallTask = await ApiHelper.ApiCallDeleteTopping(topping);
            return topping.ToppingId;
        }
    }
}