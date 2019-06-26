using System;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;
using SecretCore;


namespace SecretWord.Models
{
    class Encoder : Notifier
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private IDocumentEncoder encoder;
        
        public Encoder(string name, IDocumentEncoder encoder)
        {
            this.name = name;
            this.encoder = encoder;
        }

        public IDocumentEncoder GetEncoder()
        {
            return encoder;
        }

        public static ObservableCollection<Encoder> LoadEncoders(string pluginsDirectory)
        {
            ObservableCollection<Encoder> res = new ObservableCollection<Encoder>();
            DirectoryInfo di = new DirectoryInfo(pluginsDirectory);
            if (!di.Exists)
                di.Create();
            foreach(FileInfo fi in di.GetFiles("*.dll"))
            {
                try
                {
                    var dllAssembly = Assembly.LoadFrom(fi.FullName);
                    foreach(Type t in dllAssembly.GetTypes())
                    {
                        var iEncoder = t.GetInterface("SecretCore.IDocumentEncoder");
                        if (iEncoder!= null)
                        {
                            IDocumentEncoder encoder = (IDocumentEncoder)Activator.CreateInstance(t);
                            res.Add(new Encoder(encoder.Name, encoder));
                        }
                    }
                }
                catch (Exception)
                {

                }
            }

            return res;
        }

    }
}
