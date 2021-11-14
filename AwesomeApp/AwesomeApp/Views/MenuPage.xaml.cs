using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        int count = 0;
        public MenuPage()
        {
            InitializeComponent();
        }

        void FungsiTombol(Object sender,System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times";

        }


    }
}