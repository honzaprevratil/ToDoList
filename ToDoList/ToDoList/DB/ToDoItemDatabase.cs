﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Abstract;
using Xamarin.Forms;

namespace ToDoList
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
            database.CreateTableAsync<Category>().Wait();
        }

        public Task<List<T>> GetItemsAsync<T>() where T : ATable, new()
        {
            return database.Table<T>().ToListAsync();
        }

        public Task<T> GetItemAsync<T>(int id) where T : ATable, new()
        {
            return database.Table<T>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync<T>(T item) where T : ATable, new()
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync<T>(T item) where T : ATable, new()
        {
            return database.DeleteAsync(item);
        }
    }
}