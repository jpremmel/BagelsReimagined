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
            var apiCallTask = ApiHelper.ApiCall("bagels");
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Bagel> bagelList = JsonConvert.DeserializeObject<List<Bagel>>(jsonResponse.ToString());
            
            return bagelList;
        }
    }
}