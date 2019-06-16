using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWord.ViewModels
{
    class MainViewModel : Notifier
    {
        private IDocument doc;
        public IDocument Doc
        {
            get { return doc; }
            set
            {
                doc = value;
                NotifyPropertyChanged("Doc");
            }
        }



        public MainViewModel()
        {
            Doc = new Models.Document("Добро пожаловать!");
        }



    }
}
