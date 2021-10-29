using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyCalorieTracker.Models
{
    public interface SQLiteDBInterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}
