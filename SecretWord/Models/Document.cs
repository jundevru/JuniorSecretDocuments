using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWord.Models
{
    class Document : Notifier, IDocument
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                NotifyPropertyChanged("Text");
            }
        }

        public Document(string text)
        {
            Text = text;
        }

    }
}
