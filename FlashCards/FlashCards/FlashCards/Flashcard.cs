using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards
{
    class Flashcard
    {
        public string Topic { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        

        public Flashcard(string topic, string question, string answer)
        {
            Topic = topic;
            Question = question;
            Answer = answer;
        }
    }
}
