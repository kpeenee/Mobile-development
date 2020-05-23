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
        public void RemoveFlashcard(Flashcard card)
        {
            int cardToRemove = 0;
            bool isRemoved = false;
            do
            {
                if(card.Question == Flashcards[cardToRemove].Question)
                {
                    Flashcards.RemoveAt(cardToRemove);
                    isRemoved = true;
                }
                else
                {
                    cardToRemove++;
                }

            } while (isRemoved == false);
            SaveSystem.Save(flashcards);
        }
     
        public void EditFlashcard(Flashcard originalCard, Flashcard editFlashcard)
        {
            
            SaveSystem.Save(flashcards);
        }

        
    }
}
