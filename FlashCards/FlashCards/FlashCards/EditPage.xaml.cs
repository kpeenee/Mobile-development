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
    public partial class EditPage : ContentPage
    {
        ObservableCollection<Flashcard> usersCards ;
        public EditPage(ObservableCollection<Flashcard> cards)
        {
            InitializeComponent();
            usersCards = cards;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Flashcard original = this.BindingContext as Flashcard;
            Flashcard editedCard = new Flashcard(entTopic.Text, entQuestion.Text, entAnswer.Text);
            bool isEdit = false;
            int index = 0;
            do
            {
                if(usersCards[index].Question == original.Question)
                {
                    usersCards[index] = editedCard;
                    isEdit = true;
                }
                else
                {
                    index++;
                }
            } while (isEdit == false);
            SaveSystem.Save(usersCards);
            DisplayAlert("Edit",  "Flashcard has been changed" , "OK");
            Navigation.PopAsync();
        }
    }
}