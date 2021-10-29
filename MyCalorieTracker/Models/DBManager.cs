using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCalorieTracker.Models
{
    public class DBManager
    {
        SQLiteAsyncConnection _connection;
        public DBManager()
        {
            _connection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
            //_connection1 = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
            //_connection2 = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
        }

        public async Task<ObservableCollection<DiaryEntry>> GetEntryTable()
        {
            // create a new table if none exists
            await _connection.CreateTableAsync<DiaryEntry>();
            // select * from ToDoTask
            var entriesFromDB = await _connection.Table<DiaryEntry>().ToListAsync();
            // Convert listAysnc to an Observable Collection
            var allEntries = new ObservableCollection<DiaryEntry>(entriesFromDB);
            return allEntries;
        }
        public async Task<ObservableCollection<FoodItem>> GetFoodTable()
        {
            // create a new table if none exists
            await _connection.CreateTableAsync<FoodItem>();
            // select * from ToDoTask
            var entriesFromDB = await _connection.Table<FoodItem>().ToListAsync();
            // Convert listAysnc to an Observable Collection
            var allEntries = new ObservableCollection<FoodItem>(entriesFromDB);
            return allEntries;
        }
        public async void InsertNewEntry(DiaryEntry newEntry)
        {
            // insert into DiaryEntry values ()
            await _connection.InsertAsync(newEntry);
        }

        public async void updateEntry(DiaryEntry toUpdate)
        {
            // update where id == id 
            await _connection.UpdateAsync(toUpdate);
        }

        public async void deleteEntry(DiaryEntry toDelete)
        {
            // update where id == id 
            await _connection.DeleteAsync(toDelete);
        }
    }
}
