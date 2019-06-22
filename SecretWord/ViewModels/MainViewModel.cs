using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SecretWord.Models;
using System.Windows.Input;

namespace SecretWord.ViewModels
{
    class MainViewModel : DependencyObject
    {

        public IDocument Doc
        {
            get { return (IDocument)GetValue(DocProperty); }
            set { SetValue(DocProperty, value); }
        }
        public static readonly DependencyProperty DocProperty =
            DependencyProperty.Register("Doc", typeof(IDocument), typeof(MainViewModel), new PropertyMetadata(null));

        public ICommand TestClick => new CommandsDelegate( (obj) => {
            TestViewModel tvm = new TestViewModel();
            ChildDialogs.ChildDialog cd = new ChildDialogs.ChildDialog("123", tvm);
            Doc.Text = tvm.Text + ", " + cd.DialogResult;
        });


        public MainViewModel()
        {
            Doc = new Models.Document("Добро пожаловать!");
        }



    }
}
