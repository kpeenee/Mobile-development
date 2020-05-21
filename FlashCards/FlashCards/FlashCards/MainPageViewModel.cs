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
            flashcards = SaveSystem.Load();
        }
    }
}
