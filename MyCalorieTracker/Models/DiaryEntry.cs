using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyCalorieTracker.Models
{
    public class DiaryEntry
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string servingSize { get; set; }
        public double serving { get; set; }
        public DateTime dateAdded { get; set; }

        public double caloriesTot { get; set; }
        public double carbTot { get; set; }
        public double fatTot { get; set; }
        public double proteinTot { get; set; }

        public string title { get; set; }
        public string image { get; set; }

        [ForeignKey(typeof(FoodItem))]
        public int foodItemId { get; set; }

        [ManyToOne]
        public FoodItem food { get; set; }

        public DiaryEntry()
        {
            dateAdded = DateTime.Now;
            title = "invalid";
            image = "";
        }

        public DiaryEntry(double serv, double cal, double carb, double fat, double pro, FoodItem foo)
        {
            dateAdded = DateTime.Now;
            serving = serv;
            caloriesTot = serv * cal;
            carbTot = serv * carb;
            fatTot = serv * fat;
            proteinTot = serv * pro;
            food = foo;
            foodItemId = foo.primaryKey;
            title = food.title;
            image = food.image;
        }
    }
}
