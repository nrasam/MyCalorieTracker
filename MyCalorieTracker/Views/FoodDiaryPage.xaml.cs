using MyCalorieTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCalorieTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodDiaryPage : ContentPage
    {
        ObservableCollection<DiaryEntry> allEntries = new ObservableCollection<DiaryEntry>();
        DBManager dbModel = new DBManager();
        int remainder = 0, fromFood = 0;
        public FoodDiaryPage()
        {
            InitializeComponent();
            // Pull to refresh command for foodItemList
            foodItemList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }

        void CalculateGoal()
        {
            foreach (DiaryEntry e in allEntries)
            {
                fromFood += (int)e.caloriesTot;
            }

            remainder = Convert.ToInt32(goalEntry.Text) - fromFood;
            calFromFoodlbl.Text = fromFood.ToString();
            remainderlbl.Text = remainder.ToString();
        }

        protected override async void OnAppearing()
        {
            await dbModel.GetFoodTable();
            allEntries = await dbModel.GetEntryTable();

            foodItemList.ItemsSource = null;
            foodItemList.ItemsSource = allEntries;
            foodItemList.IsRefreshing = false;

            CalculateGoal();

            base.OnAppearing();
        }

        public void deleteFromDB(object sender, EventArgs e)
        {
            // MenuItem item = (e as MenuItem);

            DiaryEntry d = (sender as MenuItem).CommandParameter as DiaryEntry;
            dbModel.deleteEntry(d);

            foodItemList.ItemsSource = null;
            foodItemList.ItemsSource = allEntries;
        }

        public async void updateDB(object sender, EventArgs e)
        {
            //DiaryEntry toupdateTask = await TaskManager.InputBox(this.Navigation, allTasksTable.SelectedItem as toDoTask);
            //dbModel.updateEntry(new DiaryEntry());
            foodItemList.ItemsSource = null;
            foodItemList.ItemsSource = allEntries;
        }

        private void foodItemList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Navigation.PushAsync(new AddFoodDetailPage(dbModel));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddFoodPage(dbModel));
        }


    }
}