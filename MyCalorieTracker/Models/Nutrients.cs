using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MyCalorieTracker.Models
{
    public class Nutrients
    {
        public string name { get; set; }
        public string title { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }

        public Nutrients()
        {

        }
        public Nutrients(string n, string t, double a, string u)
        {
            name = n;
            title = t;
            amount = a;
            unit = u;
        }
    }
}
