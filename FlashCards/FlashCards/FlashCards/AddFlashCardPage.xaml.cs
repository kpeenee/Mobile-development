using System;
using System.Collections.Generic;
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
        public AddFlashCardPage()
        {
            InitializeComponent();
        }

        private void btnNewFlashcard_Clicked(object sender, EventArgs e)
        {
           add();
        }
        async Task add()
        {
            string name = entName.Text;
            string topic = entTopic.Text;
            string question = entQuestion.Text;
            string answer = entAnswer.Text;
            DatabaseProgram DP = new DatabaseProgram();
            await DP.AddFlashcardIfDoesNotExist(new Flashcard(name, topic, question, answer));
        }
    }
}