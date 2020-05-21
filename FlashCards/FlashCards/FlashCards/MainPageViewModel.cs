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
            ObservableCollection<Flashcard> cards = new ObservableCollection<Flashcard>();
            cards.Add(new Flashcard("Computing", "What is 2 in binary?", "10"));
            cards.Add(new Flashcard("Science", "What is the chemical formula for ethanol?", "C2H5OH"));
            cards.Add(new Flashcard("Maths", "What is 27 - 7?", "20"));
            SaveSystem.Save(cards);

            flashcards = SaveSystem.Load();
        }
    }
}
