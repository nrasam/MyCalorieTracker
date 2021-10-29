using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyCalorieTracker.Models
{
    class NetworkingManager
    {
        private string url = "https://api.spoonacular.com";
        private string key = "&apiKey=7b5e9c073d6f4cceb8099e63c9ca165d";
        private string key2 = "&apiKey=ea05f9851cc3479da700810b6d7a8a82";
        private string ingredientsSearchURL = "/food/ingredients/search?query=";
        private string productsSearchURL = "/food/products/search?query=";
        private string numberURL = "&number=5";
        private string addProductInfoURL = "&addProductInformation=true";

        HttpClient client = new HttpClient();
        public NetworkingManager()
        {

        }

        public async Task<List<FoodItem>> getProductItem(string query)
        {
            string completeURL = url + productsSearchURL + query + addProductInfoURL + numberURL + key2;
            var response = await client.GetAsync(completeURL);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<FoodItem>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                RootObject foodDic = JsonConvert.DeserializeObject<RootObject>(jsonString);

                return foodDic.products;
            }
        }

        public async Task<List<FoodItem>> getIngredientItem(string query)
        {
            string completeURL = url + ingredientsSearchURL + query + key;
            var response = await client.GetAsync(completeURL);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<FoodItem>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (jsonString);
                var array = dic.ElementAt(0).Value;
                var finalList = JsonConvert.DeserializeObject<List<FoodItem>>
                     (array.ToString());
                return finalList;
            }
        }
    }
}
