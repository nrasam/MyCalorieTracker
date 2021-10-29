using MyCalorieTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCalorieTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFoodDetailPage : ContentPage
    {
        Boolean isNew = true;
        FoodItem food;
        DBManager db;
        DiaryEntry entry = new DiaryEntry();
        public AddFoodDetailPage(FoodItem foo, DBManager d)
        {
            InitializeComponent();
            db = d;
            food = foo;
            isNew = true;
            foodTitle.Text = food.title;
            callbl.Text = "Calories: " + food.calories;
            carblbl.Text = "Carbs: " + food.carb + " g";
            fatlbl.Text = "Fat: " + food.fat + " g";
            prolbl.Text = "Protein: " + food.protein + " g";
            foodImg.Source = food.image;
        }

        public AddFoodDetailPage(DiaryEntry ent, DBManager d)
        {
            db = d;
            entry = ent;
            isNew = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (isNew)
            {
                entry = new DiaryEntry(Convert.ToDouble(servingEntry.Text), food.calories, food.carb,
                    food.fat, food.protein, food);
                db.InsertNewEntry(entry);
            }
            else
            {
                db.updateEntry(entry);
            }

            Navigation.PopAsync();
        }
    }
}