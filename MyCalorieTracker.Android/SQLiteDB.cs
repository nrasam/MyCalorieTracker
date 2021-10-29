using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCalorieTracker.Models;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(MyCalorieTracker.Droid.SQLiteDB))]
namespace MyCalorieTracker.Droid
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteDB()
        {

        }

        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "todoDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}