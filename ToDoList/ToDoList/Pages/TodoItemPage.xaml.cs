using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Abstract;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage ()
		{
			InitializeComponent ();
            var dbConnection = App.Database;

            TodoItemDatabase todoItemDatabase = App.Database;
            TodoItem item = new TodoItem();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<Category> CategoriesFromDb = App.Database.GetItemsAsync<Category>().Result;

            if (CategoriesFromDb.Count == 0)
            {
                Category category = new Category
                {
                    Name = "Not classified"
                };
                App.Database.SaveItemAsync(category);

                CategoriesFromDb = App.Database.GetItemsAsync<Category>().Result;//refresh list
            }

            CategoryListView.ItemsSource = CategoriesFromDb;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            //todoItem.CategoryID = (CategoryListView.SelectedItem as Category).ID;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopModalAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopModalAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}