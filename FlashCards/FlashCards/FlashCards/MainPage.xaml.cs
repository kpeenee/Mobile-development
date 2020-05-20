using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashCards
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel;
        }

        void OnButtonAddClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddFlashCardPage());
        }

        private void lvTopics_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Answer!", viewModel.Flashcards[e.ItemIndex].Answer, "OK");
        }
    }
}
