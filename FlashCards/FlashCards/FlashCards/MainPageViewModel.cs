using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards
{
    class MainPageViewModel
    {
        public List<string> topics { get; set; } = new List<string>();

        

        public MainPageViewModel()
        {
            topics.Add("Science");
            topics.Add("Maths");
            topics.Add("French");
            topics.Add("Computing");
        }
    }
}
