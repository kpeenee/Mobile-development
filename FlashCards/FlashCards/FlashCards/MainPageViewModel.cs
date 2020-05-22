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
        public void RemoveFlashcard(int i)
        {
            flashcards.RemoveAt(i);
            SaveSystem.Save(flashcards);
        }
        public void RemoveFlashcardGroup(string topic)
        {
            foreach (var flash in flashcards)
            {
                if (flash.Topic == topic)
                {
                    flashcards.Remove(flash);
                }
            }
            SaveSystem.Save(flashcards);
        }
        public void EditFlashcard(int index, Flashcard editFlashcard)
        {
            flashcards[index].Topic = editFlashcard.Topic;
            flashcards[index].Question = editFlashcard.Question;
            flashcards[index].Answer = editFlashcard.Answer;
            SaveSystem.Save(flashcards);
        }
    }
}
