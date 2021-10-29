using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using MyCalorieTracker.Views;
using System.Threading.Tasks;

namespace MyCalorieTracker.ViewModels
{
    class FoodDiaryPageViewModel : BindableObject
    {
        public ICommand AddFood { get; private set; }
        public FoodDiaryPageViewModel()
        {
            AddFood = new Command(OnAddFood);
        }

        void OnAddFood()
        {
            //Navigation.PushAsync(new AddFoodPage());
        }
    }
}
