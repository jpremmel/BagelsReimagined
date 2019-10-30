using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BagelsR.Models
{
    public class Topping
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }

        public static List<Topping> GetToppings()
        {
            var apiCallTask = ApiHelper.ApiCall("toppings");
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            Console.WriteLine(jsonResponse);
            List<Topping> toppingList = JsonConvert.DeserializeObject<List<Topping>>(jsonResponse.ToString());

            return toppingList;
        }
    }
}