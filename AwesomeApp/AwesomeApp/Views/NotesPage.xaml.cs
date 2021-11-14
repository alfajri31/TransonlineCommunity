using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {

        string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        public NotesPage()
        {
            InitializeComponent();

            // Read the file.
            if (File.Exists(_filename))
            {
                editor.Text = File.ReadAllText(_filename);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Save the file.
            File.WriteAllText(_filename, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Delete the file.
            if (File.Exists(_filename))
            {
                File.Delete(_filename);
            }
            editor.Text = string.Empty;
        }
    }
}