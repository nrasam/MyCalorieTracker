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
    public partial class AddFoodPage : ContentPage
    {
        String query;
        ObservableCollection<FoodItem> foodItems;
        NetworkingManager manager = new NetworkingManager();
        DBManager db;
        public AddFoodPage(DBManager db)
        {
            InitializeComponent();
            this.db = db;
        }

        private async void SearchBar_SearchButtonPressedAsync(object sender, EventArgs e)
        {
            var listFromAPI = await manager.getProductItem(query);
            foodItems = new ObservableCollection<FoodItem>();
            foreach (FoodItem i in listFromAPI)
            {
                //var imageURL = "https://spoonacular.com/cdn/ingredients_100x100/" + i.image;
                foodItems.Add(new FoodItem(i.id, i.title, i.image, i.nutrition));
            }
            searchResultsList.ItemsSource = foodItems;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            query = e.NewTextValue;
        }

        private void searchResultsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new AddFoodDetailPage(e.SelectedItem as FoodItem, db));
        }
    }
}