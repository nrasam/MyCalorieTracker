using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MyCalorieTracker.Models
{
    public class Nutrition
    {
        public List<Nutrients> nutrients { get; set; }

        public Nutrition()
        {

        }
    }
}
