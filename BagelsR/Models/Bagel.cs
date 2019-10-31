using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

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

        public static async Task<int> EditBagel(Bagel bagel)
        {
            var apiCallTask = await ApiHelper.ApiCallEditBagel(bagel);
            return bagel.BagelId;
        }

        public static async Task<int> CreateBagel(Bagel bagel)
        {
            var apiCallTask = await ApiHelper.ApiCallCreateBagel(bagel);
            return bagel.BagelId;
        }
    }
}