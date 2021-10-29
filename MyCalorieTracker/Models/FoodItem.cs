using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalorieTracker.Models
{
    public class FoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int primaryKey { set; get; }
        // id from API
        public int id { set; get; }

        [MaxLength(255)]
        public string title { set; get; }
        public string image { set; get; }
        public string type { get; set; }

        // Food Nutrition Info
        [Ignore]
        public Nutrition nutrition { get; set; }
        public double calories { get; set; }
        public double carb { get; set; }
        public double fat { get; set; }
        public double protein { get; set; }
        
        [Ignore]
        public Servings servings { get; set; }

        [OneToMany]
        public List<DiaryEntry> diaryEntries { get; set; }

        public FoodItem()
        {
            id = -1;
            title = "invalid";
            image = "";
            calories = 0;
            type = "product";
            nutrition = new Nutrition();
            servings = new Servings();
        }

        public FoodItem(int i, string t, string img, Nutrition nu)
        {
            id = i;
            title = t;
            image = img;    // Ex. banana-chips.jpg
            nutrition = nu;
            foreach (Nutrients n in nutrition.nutrients)
            {
                if (n.name == "Carbohydrates")
                {
                    carb = n.amount;
                }
                else if (n.name == "Fat")
                {
                    fat = n.amount;
                }
                else if (n.name == "Protein")
                {
                    protein = n.amount;
                }
                else if (n.name == "Calories")
                {
                    calories = n.amount;
                }
            }
        }
    }
}
