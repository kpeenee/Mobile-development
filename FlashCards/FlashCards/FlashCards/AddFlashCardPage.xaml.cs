using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFlashCardPage : ContentPage
    {
        ObservableCollection<Flashcard> usersCards;
        public AddFlashCardPage(ObservableCollection<Flashcard> theFlashcards)
        {
            InitializeComponent();
            usersCards = theFlashcards;
        }

        private void btnNewFlashcard_Clicked(object sender, EventArgs e)
        {
            if (usersCards != null)
            {
                usersCards.Add(new Flashcard(entTopic.Text, entQuestion.Text, entAnswer.Text));
            }
            else
            {
                usersCards = new ObservableCollection<Flashcard>();
                usersCards.Add(new Flashcard(entTopic.Text, entQuestion.Text, entAnswer.Text));
            }
            SaveSystem.Save(usersCards);
            DisplayAlert("Save", "Save successful", "OK");
            entQuestion.Text = "";
            entAnswer.Text = "";
            entTopic.Text = "";
        }
        
    }
}