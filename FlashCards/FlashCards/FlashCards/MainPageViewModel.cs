using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCards
{
    class MainPageViewModel
    {
        public ObservableCollection<Flashcard> flashcards = new ObservableCollection<Flashcard>();
        public ObservableCollection<Flashcard> Flashcards { get { return flashcards; }}

        

        public MainPageViewModel()
        {
            flashcards.Add(new Flashcard("Question1", "Computing", "What is 2 in binary?", "10"));
            flashcards.Add(new Flashcard("Question2", "Science", "What is the chemical formula for ethanol?", "C2H5OH"));
        }
    }
}
