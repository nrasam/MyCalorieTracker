using MyCalorieTracker.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCalorieTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FoodDiaryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
