using Foundation;
using MyCalorieTracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(MyCalorieTracker.iOS.SQLiteDB))]
namespace MyCalorieTracker.iOS
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "todoDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}