using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Adding items
            /*
 
            var dbConnection = App.Database;

            TodoItemDatabase todoItemDatabase = App.Database;
            TodoItem item = new TodoItem();
            item.Name = "Homework";
            item.Text = "Complete To-Do list.";
            item.Done = true;
            App.Database.SaveItemAsync(item);*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<TodoItem> itemsFromDb = App.Database.GetItemsAsync<TodoItem>().Result;
            DebugData(itemsFromDb);

            ItemsCount.Text = "TO-DO-es: " + itemsFromDb.Count;
            ToDoItemsListView.ItemsSource = itemsFromDb;
        }

        public void DebugData(List<TodoItem> ItemsToPrint)
        {
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(ItemsToPrint.Count);
            foreach (TodoItem todoItem in ItemsToPrint)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("Setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }

    }
}
