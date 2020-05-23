using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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
            Navigation.PushAsync(new AddFlashCardPage(viewModel.Flashcards));
        }

        private void lvTopics_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Answer!!", viewModel.Flashcards[e.ItemIndex].Answer, "OK");
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var card = mi.BindingContext as Flashcard;

            var editPage = new EditPage(viewModel.Flashcards);
            editPage.BindingContext = card;
            Navigation.PushAsync(editPage);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var card = mi.BindingContext as Flashcard;
            viewModel.RemoveFlashcard(card);
            DisplayAlert("Deleted ",  card.Question + " Has been deleted", "OK");
            
        }

        
    }
}
