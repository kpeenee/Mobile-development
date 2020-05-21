using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FlashCards
{
    public static class SaveSystem
    {
        public static void Save(ObservableCollection<Flashcard> userFlashcards)
        {
            BinaryFormatter formater = new BinaryFormatter();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "data.txt");
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

            formater.Serialize(fs, userFlashcards);
            fs.Close();
        }

        public static ObservableCollection<Flashcard> Load()
        {
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "data.txt"); ;
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open,FileAccess.ReadWrite);

                if (stream.Length == 0)
                {
                    stream.Close();
                    return null;
                }

                ObservableCollection<Flashcard> userFlashcards = formatter.Deserialize(stream) as ObservableCollection<Flashcard>;
                stream.Close();

                return userFlashcards;
            }
            else
            {
                return null;
            }
        }
    }
}
