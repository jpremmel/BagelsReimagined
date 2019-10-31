using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BagelsR.Models
{
    public class Bagel
    {
        public int BagelId { get; set; }
        public string Flavor { get; set; }
        public string SuggestedToppings { get; set; }

        public static List<Bagel> GetBagels()
        {
            var apiCallTask = ApiHelper.ApiCall("bagels", 0);
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Bagel> bagelList = JsonConvert.DeserializeObject<List<Bagel>>(jsonResponse.ToString());
            
            return bagelList;
        }

        public static Bagel GetBagel(int id)
        {
            var apiCallTask = ApiHelper.ApiCall("bagels", id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Bagel bagel = JsonConvert.DeserializeObject<Bagel>(jsonResponse.ToString());

            return bagel;
        }

        public static async void EditBagel(Bagel bagel)
        {
            var apiCallTask = await ApiHelper.ApiCallEditBagel(bagel);
        }
    }
}