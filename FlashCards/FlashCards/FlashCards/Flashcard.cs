using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FlashCards
{
    class Flashcard
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public Flashcard(string name, string topic, string question, string answer)
        {
            Name = name;
            Topic = topic;
            Question = question;
            Answer = answer;
        }
    }
}
