using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBooks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public NewBookPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            Book book = new Book()
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Book>();
                var numberOfRows = conn.Insert(book);

                if (numberOfRows > 0)
                    DisplayAlert("Success", "Book successfully inserted", "Close");
                else
                    DisplayAlert("Failed", "Book failed to be inserted", "Close");

                //conn.Dispose(); - No need for Dispose() if using "using".
            }
            //DisplayAlert("Success", "We have handled the click event", "Close");
        }
    }
}