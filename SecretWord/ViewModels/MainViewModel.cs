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


        public ICommand NewDocument => new CommandsDelegate((obj) => {
            Doc = new Models.Document("Новый документ");
            });

        public ICommand LoadDocument => new CommandsDelegate((obj) => {
            SelectEncoderViewModel sevm = new SelectEncoderViewModel();
            ChildDialogs.ChildDialog cd = new ChildDialogs.ChildDialog("Декодирование документа", sevm);
            if (cd.DialogResult != true 
                || sevm.SelectedEncoder == null)
                    return;

            ChildDialogs.IFileDialog loadFileDialog = new ChildDialogs.SecretFileDialog();
            string fileName = loadFileDialog.Load();
            if (fileName == "")
                return;

            Streams.ISecretStream filestream = new Streams.SecretFileStream(fileName);
            Doc = filestream.Load(sevm.SelectedEncoder.GetEncoder(), sevm.EncodeKey);
            if (Doc == null)
                Doc = new Models.Document("Ошибка загрузки файла...");

        });

        public ICommand SaveDocument => new CommandsDelegate((obj) => {
            SelectEncoderViewModel sevm = new SelectEncoderViewModel();
            ChildDialogs.ChildDialog cd = new ChildDialogs.ChildDialog("Кодирование документа", sevm);
            if (cd.DialogResult != true
                || sevm.SelectedEncoder == null)
                return;

            ChildDialogs.IFileDialog saveFileDialog = new ChildDialogs.SecretFileDialog();
            string fileName = saveFileDialog.Save();
            if (fileName == "")
                return;

            Streams.ISecretStream filestream = new Streams.SecretFileStream(fileName);
            if (!filestream.Save(Doc, sevm.SelectedEncoder.GetEncoder(), sevm.EncodeKey))
                MessageBox.Show("Ошибка сохранения файла");
        });


        public MainViewModel()
        {
            Doc = new Models.Document("Добро пожаловать!");
        }



    }
}
