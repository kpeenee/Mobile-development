﻿using System;
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
           
        }
        
    }
}