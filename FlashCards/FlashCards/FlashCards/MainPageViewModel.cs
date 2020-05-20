﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;


namespace FlashCards
{
    class MainPageViewModel
    {
        public ObservableCollection<Flashcard> flashcards = new ObservableCollection<Flashcard>();
        public ObservableCollection<Flashcard> Flashcards { get { return flashcards; }}

        

        

        public MainPageViewModel()
        {
            flashcards.Add(new Flashcard("Computing", "What is 2 in binary?", "10"));
            flashcards.Add(new Flashcard("Science", "What is the chemical formula for ethanol?", "C2H5OH"));
        }

      
    }
}
